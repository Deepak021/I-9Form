using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace I_9Form.Data
{
    public interface IEmployeeRepository
    {
        Task<List<Invitee>> GetInviteesForCompany(string EmployeeID);
        Task<Invitee> GetInviteeById(int id);
        Task<bool> CreateInvitee(Invitee invite);
        Task<bool> UpdateInvitee(int id, Invitee invite);
        Task<bool> DeleteInvitee(Invitee invite);
    }
    public class Invitee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public int Count { get; set; }
        [Required]
        public RoleName Role { get; set; }
        //To make Data Compatible with Front-End JS may need to do string
        public DateTime LastInvitaionDate { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address"), StringLength(50, ErrorMessage = "Max 50 characters in Email")]
        public String Email { get; set; }
        // Later Once Invitation is accepted this will be used to mark accepted by comapring with Application User
        public bool? Accepted { get; set; }
    }
    public enum RoleName
    {
        Company,
        Employee
    }
}
