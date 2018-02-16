using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ProgramasMobilidadeESW2017.Services;

namespace ProgramasMobilidadeESW2017.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirmar Conta",
                $"Por favor confirme a sua conta no seguinte <a href='{HtmlEncoder.Default.Encode(link)}'>endereço</a>");
        }
    }
}
