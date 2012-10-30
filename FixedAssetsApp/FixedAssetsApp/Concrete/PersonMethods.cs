using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Concrete
{
    public class PersonMethods
    {
        private ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public PersonMethods()
        {
            GetAllPersons();
        }

        private void GetAllPersons()
        {
            using (FixedAssetsWebService.PersonServiceClient Client = new FixedAssetsWebService.PersonServiceClient())
            {
                Client.Open();
                object[] list = Client.GetAllPersons();
                foreach (Person person in list)
                {
                    persons.Add(person);
                }
            }
        }


        public ObservableCollection<Person> CreatePersonList()
        {
            return persons;
        }

        public string GetNameById(int id)
        {
            Person person = persons.FirstOrDefault(x => x.id == id);
            if (person != null)
            {
                return person.name;
            }
            else
            {
                return string.Empty;
            }
        }
        public string GetNameSurnameIdByID(int id)
        {
            Person person = persons.FirstOrDefault(x => x.id == id);
            if (person != null)
            {
                return person.surname + " " + person.name + " - " + person.id.ToString();
            }
            else
            {
                return string.Empty;
            }
        }


        public static string GetNameAndSurnameByIdWebServiceMethod(int id)
        {
            string name = string.Empty;
            using (FixedAssetsWebService.PersonServiceClient Client = new FixedAssetsWebService.PersonServiceClient())
            {
                Client.Open();
                Person person = Client.GetPersonById(id);
                if (person != null)
                {
                    return person.surname + " " + person.name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string[] GetAllPersonsAsStringArray()
        {
            var list = persons.Select(x => new { x.name, x.surname, x.id }).Distinct();
            List<string> listPersons = new List<string>();
            foreach (var person in list)
            {
                listPersons.Add(person.surname + " " + person.name + " - " + person.id);
            }
            listPersons.Sort();
            return listPersons.ToArray();
        }

    }
}
