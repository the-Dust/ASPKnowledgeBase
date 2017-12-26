﻿using ASPKnowledgeBase.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ASPKnowledgeBase.Infrastructure
{
    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);

            if (result)
                FormsAuthentication.SetAuthCookie(username, false);
            return result;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}