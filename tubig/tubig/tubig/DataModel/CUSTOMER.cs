using System;
using System.ComponentModel.DataAnnotations;
namespace tubig.DataModel
{
    public class CUSTOMER
    {
        //public string CusID { get; set; }
        public Guid CusID { get; set; }
        //  public int CusID { get; set; }
        [Required]
        public string CusFirstName { get; set; }
        [Required]
        public string CusLastName { get; set; }
        [Required]

        public string CusMiddleName { get; set; }
        public string CusContactNumber { get; set; }
        [Required]
        public string CusEmail { get; set; }
        [Required]
        public string CusBirthOfDate { get; set; }
        [Required]
        public string CusAddress { get; set; }
        [Required]
       
      
        public string CusPassword { get; set; }
        [Required]
        public string CusSecurityQuestion { get; set; }
        [Required]
        public string CusSecurityQuestionAnswer { get; set; }
        [Required]

        public string CusValiIdImage { get; set; }
        [Required]
        public string CusIdType { get; set; }

        
    }
}
