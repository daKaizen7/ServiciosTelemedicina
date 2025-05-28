using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Factories
{
        public static class UsuarioFactory
        {
            public static Usuario? CrearUsuario(UsuarioDTO dto)
            {   
                // Verifica si es Administrador
                if (dto.Activo.HasValue)
                {
                    return new Administrador
                    {
                        Cedula = dto.Cedula,
                        Nombre = dto.Nombre,
                        Apellido = dto.Apellido,
                        Contrasena = dto.Contrasena,
                        Telefono = dto.Telefono,
                        Correo = dto.Correo,
                        FechaNacimiento = dto.FechaNacimiento,
                        Activo = dto.Activo,
                        Permisos = dto.Permisos,
                        Rol= "Administrador"
                    };
                }

                // Verifica si es Paciente
                if (!string.IsNullOrEmpty(dto.Direccion))
                {
                    return new Paciente
                    {
                        Cedula = dto.Cedula,
                        Nombre = dto.Nombre,
                        Apellido = dto.Apellido,
                        Contrasena = dto.Contrasena,
                        Telefono = dto.Telefono,
                        Correo = dto.Correo,
                        FechaNacimiento = dto.FechaNacimiento,
                        Direccion = dto.Direccion,
                        Rol = "Paciente"
                    };
                }

                // Verifica si es Terapeuta
                if (!string.IsNullOrEmpty(dto.Cargo))
                {
                    return new Terapeuta
                    {
                        Cedula = dto.Cedula,
                        Nombre = dto.Nombre,
                        Apellido = dto.Apellido,
                        Contrasena = dto.Contrasena,
                        Telefono = dto.Telefono,
                        Correo = dto.Correo,
                        FechaNacimiento = dto.FechaNacimiento,
                        Cargo = dto.Cargo,
                        Rol = "Terapeuta"
                    };
                }

                // Si no coincide con ningún tipo, devuelve null
                return null;
            }
        }
}