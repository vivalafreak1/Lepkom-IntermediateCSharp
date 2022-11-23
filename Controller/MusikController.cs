using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pert6_50420221.Models;

namespace pert6_50420221.Controllers
{
    public class MusikController : ApiController
    {
        private List<Musik> listMusik = new List<Musik>
        {
            new Musik{
                id = 1,
                judul = "Lepkom Ceria",
                penyanyi = "Arief Taufik Rahman",
                tahun = 2022,
            },
            new Musik{
                id = 2,
                judul = "Lepkom Baka Mitai",
                penyanyi = "Arief Rahman",
                tahun = 2022,
            },
        };

        public IEnumerable<Musik> Get()
        {
            return listMusik;
        }

        public Musik Get(int id)
        {
            var musik = listMusik.FirstOrDefault(m => m.id == id);
            return musik;
        }

        public IEnumerable<Musik> Post([FromBody] Musik musik)
        {
            var musikID = listMusik.Last().id + 1;

            musik.id = musikID;
            listMusik.Add(musik);

            return listMusik;
        }

        public IEnumerable<Musik> Put(int id, [FromBody] Musik musik)
        {
            var musikID = listMusik.IndexOf(listMusik.FirstOrDefault(m => m.id == id));

            listMusik[musikID].judul = musik.judul;
            listMusik[musikID].penyanyi = musik.penyanyi;
            listMusik[musikID].tahun = musik.tahun;

            return listMusik;
        }

        public IEnumerable<Musik> Delete(int id, [FromBody] Musik musik)
        {
            var musikID = listMusik.IndexOf(listMusik.FirstOrDefault(m => m.id == id));

            listMusik.RemoveAt(musikID);
            return listMusik;
        }
    }
}
