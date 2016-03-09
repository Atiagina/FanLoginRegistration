using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FanLoginRegistrationService" in code, svc and config file together.
public class FanLoginRegistrationService : IFanLoginRegistrationService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
	
        public int FanRegistration(FanLite f){

            FanLogin fl = new FanLogin();
            int result = ste.usp_RegisterFan(f.FanName, f.FanEmail, f.FanUsername, f.FanPassword);
            return result;
        }

        public int FanLogin(string username, string password)
        {
            int result = ste.usp_FanLogin(username, password);

            if (result != -1)
            {
                var key = from k in ste.FanLogins
                          where k.FanLoginUserName.Equals(username)
                          select new {k.FanLoginKey};

                          foreach (var k in key){

                              result = (int)k.FanLoginKey;
                          }

            }
            return result;
        }
	}

