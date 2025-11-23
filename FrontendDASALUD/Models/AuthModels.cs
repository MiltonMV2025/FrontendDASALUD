namespace FrontendDASALUD.Models
{
    public class UserCredentials
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthData
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public int IdEspecialidad { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }

    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool Result { get; set; }
        public T? Data { get; set; }
    }
}
