/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;

namespace ATML1671Translator.exceptions
{
    public class TranslationException : Exception
    {
        public TranslationException() : base()
        {
            
        }

        public TranslationException(String message) : base(message)
        {
            
        }

        public TranslationException(String message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}