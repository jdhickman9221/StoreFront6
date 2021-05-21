using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StoreFront6.UI.MVC.Models
{
    public class ContactViewModel
    {
        //1. created new class for contact view model

        //No fields, using auto prop syntax - fields get created at runtime. 
        //Its good to not use auto props for bizz rules and or read only.

        //2. create auto props for email sections.
        //3. Add Using statement for System.ComponentModel.DataAnnotations;
        //4. Add required and Ui hint for text area.
        //5.NOW delete the Home View Contact
        //6. Go to home controller and right click, add view to CONTACT.
        //7. In the add view window, Add Contact to view name, Create template, Model Class: Contact View Model, and use a layout page.
        [Required(ErrorMessage = "*Name is required")]
        [StringLength(50, ErrorMessage ="Must not be more than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Email is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]//This give you standard validation.
        public string Email { get; set; }


        public string Subject { get; set; }
        [Required(ErrorMessage = "*Subject and Message both required")]
        [UIHint("MultilineText")]//UI hint for multi instead of single line. This means when it scaffolds, it creates the input of text area.
        public string Message { get; set; }
    }
}