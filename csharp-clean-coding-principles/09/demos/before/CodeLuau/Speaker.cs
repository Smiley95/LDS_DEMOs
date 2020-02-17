namespace CodeLuau
{
    public class Speaker
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int? YearsExperience { get; set; }
		public bool HasBlog { get; set; }
		public string BlogURL { get; set; }
		public WebBrowser Browser { get; set; }
		public List<string> Certifications { get; set; }
		public string Employer { get; set; }
		public int RegistrationFee { get; set; }
		public List<Session> Sessions { get; set; }

		public RegisterResponse Register(IRepository repository)
		{
            int? speakerId = null;

            var error = ValidateData();
            if (ValidateData() == null) return new RegisterError(error);
            var emailDomains = new List<string>() { "aol.com", "prodigy.com", "compuserve.com" };
            string emailDomain = Email.Split('@').Last();
            var IsQualified = IsExceptional()|| HasDomain();
            if (!IsQualified) return RegisterError.SpeakerDoesNotMeetStandards;
            bool approved = false;
            if (Sessions.Count() == 0) return RegisterError.NoSessionsProvided;
                foreach (var session in Sessions)
				{
                approved = SessionForOldTechnologies(session);
				}

				if (!approved) return RegisterError.NoSessionsApproved;
                    try
					{
					    speakerId = repository.SaveSpeaker(this);
					}
					catch (Exception e)
					{
					}
			return new RegisterResponse((int)speakerId);
		}
        public RegisterError? ValidateData()
        {
            if (string.IsNullOrWhiteSpace(FirstName)) return RegisterError.FirstNameRequired;
            if (string.IsNullOrWhiteSpace(LastName)) return RegisterError.LastNameRequired;
            if (string.IsNullOrWhiteSpace(Email)) return RegisterError.EmailRequired;
            return null;

        }
        public bool IsExceptional()
        {
            var employers = new List<string>() { "Pluralsight", "Microsoft", "Google" };
            return YearsExperience > 10 || HasBlog || Certifications.Count() > 3 || employers.Contains(Employer);
        }
        public bool HasDomain()
        {
            var emailDomains = new List<string>() { "aol.com", "prodigy.com", "compuserve.com" };
            string emailDomain = Email.Split('@').Last();
            return !emailDomains.Contains(emailDomain) && (!(Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9));

        }
        public bool SessionForOldTechnologies(Session session)
        {
            var oldTechnologies = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
            foreach (var technology in oldTechnologies)
            {
                if (session.Title.Contains(technology) || session.Description.Contains(technology)) return true;
            }
            return false;
        }
    }
}