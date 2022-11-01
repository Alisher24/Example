using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AeroDataContext();
            // выбираем из таблицы пассажира с индексом 38
            var query = from c in db.Passenger
                        where c.ID_psg == 38
                        select c;
            foreach (var q in query)
            {
                db.Passenger.DeleteOnSubmit(q);  // ставим в очередь на удаление
            }
            db.SubmitChanges();
            query = from c in db.Passenger
                    select c;
            foreach (var q in query)
            {
                Console.WriteLine(q.ID_psg + ". " + q.name);
            }
            Console.ReadKey();
        }
    }
}
