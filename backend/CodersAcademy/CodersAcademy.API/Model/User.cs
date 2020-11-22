using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public String  Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Photo { get; set; }

        public IList<UserFavoriteMusic> FavoriteMusics { get; set; }

        public void AddFavoriteMusic(Music music)
        {
            this.FavoriteMusics.Add(new UserFavoriteMusic()
            {
                Music = music,
                MusicId = music.Id,
                User = this,
                UseriId = this.Id
            });
        }

        public void RemoveFavoriteMusic(Music music)
        {
            var favMusic = this.FavoriteMusics
                               .Where(x => x.MusicId == music.Id)
                               .FirstOrDefault();

            //Somente no C# 9 -> .NET 5
            if (favMusic is null)
                throw new Exception("Música não encontrada na Lista de Favoritos");

            this.FavoriteMusics.Remove(favMusic);
        }
    }
}
