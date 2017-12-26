using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPKnowledgeBase.Infrastructure.Base
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);

        void SignOut();
    }
}