﻿namespace EstaparBackoffice.DTO.Authorization
{
    public class UserTokenViewModel
    { 
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }
}
