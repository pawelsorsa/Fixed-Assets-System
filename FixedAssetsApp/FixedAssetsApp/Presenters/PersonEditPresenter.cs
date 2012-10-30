using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.UserControlls;
using FixedAssetsApp.Model;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Presenters
{
    public class PersonEditPresenter : PresenterBase<PersonEditView>
    {
        private PersonModel _personSection;
        public PersonEditPresenter(PersonEditView personEditView, PersonModel personSection)
            : base(personEditView) 
        {
            _personSection = personSection;
            personEditView.DataContext = _personSection;
            SectionMethods sm = new SectionMethods();
            personEditView.ComboBox_Sections.ItemsSource = sm.GetAllSectionsAsShortNameList();
            personEditView.ComboBox_Sections.SelectedItem = personSection.short_section_name;

            if (personEditView.ComboBox_Sections.SelectedValue == null)
            {
                personEditView.ComboBox_Sections.SelectedIndex = 1;
            }
        }
    }
}

