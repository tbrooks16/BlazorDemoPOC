using System.ComponentModel.DataAnnotations;
using BlazorDemoPOC.Client.Validators;

namespace BlazorDemoPOC.Models;
public class Person {
        public int Id { get; set; }
        [Required] public string FirstName {get; set;}
        [Required] public string LastName {get; set;}
        [Required] public string Username {get; set;}
        // TODO Test if PhoneValidationw works on the client in the server folder.
        [Required, Phone, PhoneValidation] public string PhoneNumber {get; set;} = ""; // Yes I could have used RegExp data annotation but this is just for demonstration. 
        [Required] public string Roles {get; set;} = "qa";
    }