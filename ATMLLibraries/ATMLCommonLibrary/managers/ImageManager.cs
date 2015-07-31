/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using ATMLCommonLibrary.Properties;

namespace ATMLCommonLibrary.managers
{
    public class ImageManager
    {
        private static readonly object syncRoot = new Object();
        private static volatile ImageManager _instance;

        public static ImageManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new ImageManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public static Image GetImage(string name)
        {
            Image image = Resources.ResourceManager.GetObject(name) as Bitmap;
            return image;
        }
    }
}