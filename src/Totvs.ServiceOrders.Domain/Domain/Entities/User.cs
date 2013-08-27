using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Usuário do Sistema
    /// </summary>
    public class User : Entity
    {
        public User(string userName, string password)
        {
            UserName = userName;
            DefineNewPassword(password);
        }

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public Guid Password { internal get; set; }

        /// <summary>
        /// Checa se a senha do usuário esta correta
        /// </summary>
        public bool PasswordIs(string password)
        {
            return Equals(Password, CreateHash(password));
        }

        /// <summary>
        /// Define a senha do usuário
        /// </summary>
        public void DefineNewPassword(string password)
        {
            Password = CreateHash(password);
        }

        /// <summary>
        /// Algoritimo de criação de hash
        /// </summary>
        private Guid CreateHash(string password)
        {
            using (MD5 md5Hasher = MD5.Create())
            {
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return Guid.Parse(sBuilder.ToString());
            }
        } 
    }
}
