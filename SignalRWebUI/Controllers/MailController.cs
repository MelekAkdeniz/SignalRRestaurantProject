using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dto.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        private readonly IConfiguration _configuration;

        public MailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            var email = _configuration["EmailSettings:Email"];
            var password = _configuration["EmailSettings:Password"];
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", email);
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            //bodyBuilder.TextBody = createMailDto.Body;
            bodyBuilder.HtmlBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(smtpServer, port, false);
                smtpClient.Authenticate(email, password);
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Connect("smtp.gmail.com", 587, false);           
            //smtpClient.Send(mimeMessage);
            //smtpClient.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
