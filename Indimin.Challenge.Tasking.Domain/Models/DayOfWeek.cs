using Indimin.Challenge.Tasking.Domain.Contracts;
using Indimin.Challenge.Tasking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Indimin.Challenge.Tasking.Domain.Models
{
    public class DayOfWeek : Enumeration
    {
        public static DayOfWeek Monday = new DayOfWeek(1, "Lunes");
        public static DayOfWeek Tuesday = new DayOfWeek(2, "Martes");
        public static DayOfWeek Wednesday = new DayOfWeek(3, "Miercoles");
        public static DayOfWeek Thursday = new DayOfWeek(4, "Jueves");
        public static DayOfWeek Friday = new DayOfWeek(5, "Viernes");
        public static DayOfWeek Saturday = new DayOfWeek(6, "Sabado");
        public static DayOfWeek Sunday = new DayOfWeek(7, "Domingo");
        public DayOfWeek(int id, string name) : base(id, name) { }
        public static IEnumerable<DayOfWeek> List() =>
            new[] { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
        public static DayOfWeek FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new TaskingDomainException($"Posible values for DayOfWeek: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static DayOfWeek From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new TaskingDomainException($"Possible values for DayOfWeek: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
