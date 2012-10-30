using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;


namespace FixedAssets.Concrete.Controllers
{
    public sealed class SectionController : ISectionService
    {
        private ISectionRepository repository;
        public SectionController(ISectionRepository repo)
        {
            repository = repo;
        }

        public int CountSections()
        {
            return repository.Sections.Count();
        }

        public object[] GetAllSections()
        {
            return repository.Sections.ToArray();
        }

        public Section GetSectionById(int id)
        {
            return repository.Sections.FirstOrDefault(section => section.id == id);
        }

        public Section GetSectionByName(string name)
        {
            return repository.Sections.FirstOrDefault(section => section.name == name);
        }

        public Section GetSectionByShortName(string shortname)
        {
            return repository.Sections.FirstOrDefault(section => section.short_name == shortname);
        }

        public object [] GetSectionsByPostalCode(string postalcode)
        {
            return repository.Sections.Where(section => section.postal_code == postalcode).ToArray();
        }

        public object[] GetSectionsByPost(string post)
        {
            return repository.Sections.Where(section => section.post == post).ToArray();
        }

        public object[] GetSectionsByLocality(string locality)
        {
            return repository.Sections.Where(section => section.locality == locality).ToArray();
        }

        public Section GetSectionByPhoneNumber(string phone)
        {
            return repository.Sections.FirstOrDefault(section => section.phone_number == phone);
        }

        public Section GetSectionByEmail(string email)
        {
            return repository.Sections.FirstOrDefault(section => section.email == email);
        }

        public object[] GetSectionsByStreet(string street)
        {
            return repository.Sections.Where(section => section.street == street).ToArray();
        }
    }
}
