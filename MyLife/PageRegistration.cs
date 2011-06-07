// <copyright file="PageRegistration.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;

    public class PageRegistration
    {
        private readonly string name;
        private readonly Uri pageUri;
        private readonly Uri iconUri;

        public PageRegistration(string name, string pageUri, string iconUri = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;

            if (pageUri == null)
            {
                throw new ArgumentNullException("pageUri");
            }

            this.pageUri = new Uri(pageUri, UriKind.RelativeOrAbsolute);

            if (iconUri != null)
            {
                this.iconUri = new Uri(iconUri, UriKind.RelativeOrAbsolute);
            }
        }

        public PageRegistration(string name, Uri pageUri, Uri iconUri = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;

            if (pageUri == null)
            {
                throw new ArgumentNullException("pageUri");
            }

            this.pageUri = pageUri;

            this.iconUri = iconUri;
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}
