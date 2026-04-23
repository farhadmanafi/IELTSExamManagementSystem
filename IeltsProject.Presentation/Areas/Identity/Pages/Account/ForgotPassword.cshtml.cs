using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using IeltsProject.Presentation.Models;
using IeltsProject.Presentation.EmailServer;

namespace IeltsProject.Presentation.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IEmailSender _emailSender;
        private readonly IMyEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IMyEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                _emailSender.SendEmail(
                    Input.Email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}



//    if (ModelState.IsValid)
//{
//    //var user = await UserManager.FindByNameAsync(model.Email);
//    //ApplicationUser applicationUser = new ApplicationUser();
//    //applicationUser = db.Users.FirstOrDefault(a => a.Email == model.Email);
//    var user = _userManager.FindByEmailAsync(Input.Email);
//    if (user == null) // || !(await _userManager.IsEmailConfirmedAsync(user)))
//    {
//        // Don't reveal that the user does not exist or is not confirmed
//        return RedirectToPage("./ForgotPasswordConfirmation");
//    }

//    if (user != null)
//    {
//        string EmailMassege = "Change Password";
//        string EmailMassegeTitle = "Change Password";
//        string code = user.Id.ToString();
//        var body = string.Format("{0}<BR/>" + EmailMassege + " <a href=\"{1}\" title=" + EmailMassegeTitle + ">{1}</a>",
//            Input.Email, Url.Action("ResetPassword", "/Identity/Account/", new { userId = user.Id, code = code }, Request.Scheme));
//        var message = new MailMessage();
//        //message.To.Add(new MailAddress(user.Email));
//        message.To.Add(new MailAddress("farhad.manafi@gmail.com"));  // replace with valid value 
//        message.From = new MailAddress("ForgotPassword@bpvielts.com");  // replace with valid value
//        message.Subject = "EmailConfirm"; // "Your email subject";
//        message.Body = body; // string.Format(body, model.UserName, model.Email, "asdswef");
//        message.IsBodyHtml = true;
//        var emailClient = new SmtpClient("mail.bpvielts.com");
//        emailClient.UseDefaultCredentials = false;
//        var SMTPUserInfo = new System.Net.NetworkCredential("ForgotPassword@bpvielts.com", "0&.H.!-pL_h]");
//        emailClient.Credentials = SMTPUserInfo;

//        emailClient.Send(message);

//        return RedirectToAction("ForgotPasswordConfirmation", "/Identity/Account/", new { Email = Input.Email });
//        // Don't reveal that the user does not exist or is not confirmed
//    }
//    return RedirectToPage("ForgotPasswordConfirmation", "/Identity/Account/");
//}

//return RedirectToPage("ForgotPasswordConfirmation", "/Identity/Account/");