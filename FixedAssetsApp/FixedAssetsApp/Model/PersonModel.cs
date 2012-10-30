using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Presenters;
using FixedAssetsApp.Views;
using FixedAssetsApp.Concrete;
using System.Collections.ObjectModel;

namespace FixedAssetsApp.Model
{
    public class PersonModel : ICloneable
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int? area_code { get; set; }
        public int? phone_number { get; set; }
        public int? phone_number2 { get; set; }
        public string email { get; set; }
        public int id_section { get; set; }
        public string short_section_name { get; set; }

        public static PersonModel CreatePersonSection(Person person)
        {
            SectionMethods sm = new SectionMethods();
            PersonModel temp;
            temp = new PersonModel();
            temp.id = person.id;
            temp.name = person.name;
            temp.surname = person.surname;
            temp.phone_number = person.phone_number;
            temp.phone_number2 = person.phone_number2;
            temp.area_code = person.area_code;
            temp.email = person.email;
            temp.id_section = person.id_section;
            temp.short_section_name = sm.GetShortNameById(person.id_section);
            return temp;
        }

        public static ObservableCollection<PersonModel> CreatePersonSectionList(object[] table)
        {
            SectionMethods sm = new SectionMethods();
            ObservableCollection<PersonModel> personsectionList = new ObservableCollection<PersonModel>();
            PersonModel temp;
            foreach (Person person in table)
            {
                temp = new PersonModel();
                temp.id = person.id;
                temp.name = person.name;
                temp.surname = person.surname;
                temp.phone_number = person.phone_number;
                temp.phone_number2 = person.phone_number2;
                temp.area_code = person.area_code;
                temp.email = person.email;
                temp.id_section = person.id_section;
                temp.short_section_name = sm.GetShortNameById(person.id_section);
                personsectionList.Add(temp);
            }
            return personsectionList;
        }


        public static Person CreatePerson(PersonModel ps)
        {
            Person temp = new Person();
            temp.id = ps.id;
            temp.name = ps.name;
            temp.surname = ps.surname;
            temp.area_code = ps.area_code;
            temp.email = ps.email;
            temp.id_section = ps.id_section;
            temp.phone_number = ps.phone_number;
            temp.phone_number2 = ps.phone_number2;
            return temp;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
