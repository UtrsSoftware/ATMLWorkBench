/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMLWorkBench.model
{
    public class Verb
    {
        protected List<String> statements;
        protected String[] parts;

        private String lineNo;
        public String LineNo
        {
            get { return lineNo; }
            set { lineNo = value; }
        }


        private List<Verb> children = new List<Verb>();
        public List<Verb> Children
        {
            get { return children; }
            set { children = value; }
        }

        private String command;
        public String Command
        {
            get { return command; }
            set { command = value; }
        }
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public Verb()
        {
        }

        public Verb(ref List<String> statements, ref int index)
        {
            this.statements = statements;
            this.parts = statements[index].Split(',');
            this.index = index;
            if( parts.Count() > 0 )
            {
                command = parts[0].Trim();
                int idx = command.IndexOf(" ");//--- Find first space
                if( idx != -1 )
                {
                    lineNo = command.Substring(0, idx);
                    command = command.Substring(idx).Trim();
                }
            }
            if( parts.Count() > 1 )
                name = parts[1].Trim();
            index++;
        }

        public static Verb Parse(ref List<String> statements, ref int index)
        {
            Verb verb = null;
            String statement = statements[index].Trim();
            int idx = statement.IndexOf(" ");//--- Find first space
            if( idx != -1 )
            {
                String lineNo = statement.Substring(0, idx);
                String command = statement.Substring(idx).Trim();
                String[] parts = command.Split(',');
                String verbName = parts[0].Trim();
                if( "DEFINE" == verbName )
                    verb = new Define(ref statements, ref index);
                else if( "END" == verbName )
                    verb = new End(ref statements, ref index);
                else if( "DECLARE" == verbName )
                    verb = new Declare(ref statements, ref index);
                else if( "REQUIRE" == verbName )
                    verb = new Require(ref statements, ref index);
                else if( "APPLY" == verbName )
                    verb = new Signal(ref statements, ref index);
                else
                    verb = new Verb(ref statements, ref index);
                verb.LineNo = lineNo;
            }
            return verb;
        }
    }

    public class Undefined : Verb
    {
        public Undefined(ref List<String> statements, ref int index)
            : base(ref statements, ref index)
        {
            Name = parts[0].Trim();
        }
    }

    public class Fill : Verb
    {
        public Fill(ref List<String> statements, ref int index)
            : base(ref statements, ref index)
        {
        }
    }

    public class Input : Verb
    {
        public Input(ref List<String> statements, ref int index)
            : base(ref statements, ref index)
        {
        }
    }

    public class Define : Verb
    {
        private Boolean isModule = false;

        public Define(ref List<String> statements, ref int index)
            : base( ref statements, ref index )
        {
            if( parts.Count() < 3 )
                throw new Exception("Invalid Define Statement");
            if( parts[2].StartsWith("EXT") )
            {
                isModule = true;
                Name = parts[3];
            }
            else if( parts[2].StartsWith("PROC") )
            {
                Name = parts[2];
            }
            Verb verb = Verb.Parse(ref statements, ref index );;
            while( !(verb is End && verb.Name.Equals(this.Name) ) )
            {
                Children.Add(verb);
                verb = Verb.Parse(ref statements, ref index);
            }
            Children.Add(verb); //Add the end verb
        }
    }


    public class Require : Verb
    {
        private String device;
        public String Device
        {
            get { return device; }
            set { device = value; }
        }

        private String signalType;
        public String SignalType
        {
            get { return signalType; }
            set { signalType = value; }
        }

        private String componentType;
        public String ComponentType
        {
            get { return componentType; }
            set { componentType = value; }
        }

        private Dictionary<String, String> properties = new Dictionary<string, String>();
        public Dictionary<String, String> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public Require(ref List<String> statements, ref int index)
            : base(ref statements, ref index)
        {
            if( parts.Count() >= 3 )
                device = parts[2].Trim();
            if( parts.Count() >= 4 )
                signalType = parts[3].Trim();
            if( parts.Count() >= 5 )
                componentType = parts[4].Trim();
            if( parts.Count() >= 6 )
            {
                for( int i=5; i < parts.Count(); i++ )
                {
                    String line = parts[i].Trim();
                    int idx = line.IndexOf(' ');
                    if( idx != -1 )
                        properties.Add(line.Substring(0, idx), line.Substring(idx));
                    else
                        properties.Add(line, line);
                }
            }

        }

    }


    public class End : Verb
    {
        public End(ref List<String> statements, ref int index)
            : base(ref statements, ref index)
        {

        }

    }

    public class Declare : Verb
    {
        private String type;
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        private String action;
        public String Action
        {
            get { return action; }
            set { action = value; }
        }

        Dictionary<String, String > variables = new Dictionary<string, string>();
        public Dictionary<String, String> Variables
        {
            get { return variables; }
            set { variables = value; }
        }

        private Boolean isGlobal = false;
        public Boolean IsGlobal
        {
            get { return isGlobal; }
            set { isGlobal = value; }
        }

        public Declare(ref List<String> statements, ref int index)
            : base(ref statements, ref index)
        {
            if( parts.Count() >= 3 )
            {
                int typeIdx = 2;
                int actionIdx = 3;
                int variableStartIdx = 4;
                type = parts[2].Trim();
                if( "GLOBAL".Equals(type) )
                {
                    isGlobal = true;
                    typeIdx = 3;
                    actionIdx = 4;
                    variableStartIdx = 5;
                }
                type = parts[typeIdx].Trim();
                action = parts[actionIdx].Trim();
                for( int i=variableStartIdx; i<parts.Count(); i++ )
                {
                    variables.Add(parts[i].Trim(), parts[i].Trim());
                }
            }
        }

    }
}
