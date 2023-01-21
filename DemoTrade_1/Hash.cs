using System;
using System.Collections.Generic;
using System.Text;
using HashLib;


namespace DemoTrade_1
{
    class Hash
    {
         public static HashResult getHashAmount(string convertibleString, string sold)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateKeccak512();
            HashResult temphash = hash.ComputeString(convertibleString+sold);

            return temphash;
        }


        public static User hashingUser(User user)
        {
            user.Login = getHashAmount(user.Login, "sold").ToString();
            user.Password = getHashAmount(user.Password, "sold").ToString();
            user.Name = getHashAmount(user.Name, "sold").ToString();
            user.Surname = getHashAmount(user.Surname, "sold").ToString();

            return user;
        }
    }
}
