using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;

namespace Vacations.Controllers
{
    public class SignInController : ApiController
    {
        [DataContractAttribute]
        public class Accaunt
        {
            [DataMemberAttribute]
            public int id;
            [DataMemberAttribute]
            public string login;
            [DataMemberAttribute]
            public string pass;

            public Accaunt(int id, string login, string pass)
            {
                this.id = id;
                this.login = login;
                this.pass = pass;
            }
        }

        Accaunt[] accaunts = new Accaunt[] {
                new Accaunt ( 1, "Alex1", "1234"),
                new Accaunt ( 2, "Alex2", "1234"),
                new Accaunt ( 3, "Alex3", "1234")
         };

        // GET api/values
        public IEnumerable<Accaunt> Get()
        {
            return accaunts;
        }

        // GET api/values/5
        public Accaunt Get(int id)
        {
            return accaunts.FirstOrDefault(x => x.id == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
