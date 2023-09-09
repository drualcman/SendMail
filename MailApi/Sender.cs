namespace MailApi;

public class Sender
{
    readonly SMTPOptions Options;
    readonly ILogger<Sender> Logger;

    public Sender(IOptions<SMTPOptions> options, ILogger<Sender> logger)
    {
        Options = options.Value;
        Logger = logger;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        try
        {
            MailMessage message = new MailMessage(Options.From, to);
            message.Subject = subject;
            message.Body = body;
            SmtpClient smtpClient = new SmtpClient(Options.Host, Options.Port)
            {
                Credentials = new NetworkCredential(Options.UserName, Options.Password),
                EnableSsl = true
            };
            await smtpClient.SendMailAsync(message);
        }
        catch(Exception ex)
        {
            Logger.LogError("ERROR: {0}", ex.Message);
            throw;
        }
    }
}
