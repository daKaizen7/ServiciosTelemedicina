using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;
using System;

namespace ServiciosTelemedicina.Factories
{
        public static class UsuarioFactory
        {
            public static Usuario? CrearUsuario(UsuarioDto dto)
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
                        Activo = dto.Activo
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
                        Direccion = dto.Direccion
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
                        Cargo = dto.Cargo
                    };
                }

                // Si no coincide con ningún tipo, devuelve null
                return null;
            }
        }
}