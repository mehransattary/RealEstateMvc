using MoshaverDataLayer.GenericRepository;
using MoshaverDataLayer.Model;
using MoshaverhAmlak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverDataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDbContext db = new ApplicationDbContext();

      
        private GenericRepository<City> cityRepository;
        private GenericRepository<Melk> melkRepository;
        private GenericRepository<TypeCustumer> typeCustumerRepository;      
        private GenericRepository<TypeGardad> typeGardadRepository;
        private GenericRepository<TypeMahdode> typeMahdodeRepository;
        private GenericRepository<TypeMelk> typeMelkRepository;
        private GenericRepository<TypeSanad> typeSanadRepository;
        private GenericRepository<Gallery> galleryRepository;
        //private GenericRepository<ApplicationUser> userRepository;
        private GenericRepository<Menu> menuRepository;
        private GenericRepository<ZirMenu> zirmenuRepository;
        private GenericRepository<ItemMenu> itemmenuRepository;
        private GenericRepository<Setting> settingRepository;
        private GenericRepository<Slider> sliderRepository;
        private GenericRepository<Social> socialRepository;
        private GenericRepository<Brand> brandRepository;
        private GenericRepository<Advertise> advertiseRepository;
        private GenericRepository<UsualQuestion> usualQuestionRepository;
        private GenericRepository<Comment> commentRepository;
        public GenericRepository<City> CityRepository
        {
            get
            {
                if (cityRepository == null)
                {
                    cityRepository = new GenericRepository<City>(db);
                }
                return cityRepository;
            }
        }
        public GenericRepository<Gallery> GalleryRepository
        {
            get
            {
                if (galleryRepository == null)
                {
                    galleryRepository = new GenericRepository<Gallery>(db);
                }
                return galleryRepository;
            }
        }

        public GenericRepository<Melk> MelkRepository
        {
            get
            {
                if (melkRepository == null)
                {
                    melkRepository = new GenericRepository<Melk>(db);
                }
                return melkRepository;
            }
        }

        public GenericRepository<TypeCustumer> TypeCustumerRepository
        {
            get
            {
                if (typeCustumerRepository == null)
                {
                    typeCustumerRepository = new GenericRepository<TypeCustumer>(db);
                }
                return typeCustumerRepository;
            }
        }

    
        public GenericRepository<TypeGardad> TypeGardadRepository
        {
            get
            {
                if (typeGardadRepository == null)
                {
                    typeGardadRepository = new GenericRepository<TypeGardad>(db);
                }
                return typeGardadRepository;
            }
        }
        public GenericRepository<TypeMahdode> TypeMahdodeRepository
        {
            get
            {
                if (typeMahdodeRepository == null)
                {
                    typeMahdodeRepository = new GenericRepository<TypeMahdode>(db);
                }
                return typeMahdodeRepository;
            }
        }
        public GenericRepository<TypeMelk> TypeMelkRepository
        {
            get
            {
                if (typeMelkRepository == null)
                {
                    typeMelkRepository = new GenericRepository<TypeMelk>(db);
                }
                return typeMelkRepository;
            }
        }
        public GenericRepository<TypeSanad> TypeSanadRepository
        {
            get
            {
                if (typeSanadRepository == null)
                {
                    typeSanadRepository = new GenericRepository<TypeSanad>(db);
                }
                return typeSanadRepository;
            }
        }



        //public GenericRepository<ApplicationUser> UserRepository
        //{
        //    get
        //    {
        //        if (userRepository == null)
        //        {
        //            userRepository = new GenericRepository<ApplicationUser>(db);
        //        }
        //        return userRepository;
        //    }
        //}
   
        public GenericRepository<Menu> MenuRepository
        {
            get
            {
                if (menuRepository == null)
                {
                    menuRepository = new GenericRepository<Menu>(db);
                }
                return menuRepository;
            }
        }
        public GenericRepository<ZirMenu> ZirMenuRepository
        {
            get
            {
                if (zirmenuRepository == null)
                {
                    zirmenuRepository = new GenericRepository<ZirMenu>(db);
                }
                return zirmenuRepository;
            }
        }
        public GenericRepository<ItemMenu> ItemMenuRepository
        {
            get
            {
                if (itemmenuRepository == null)
                {
                    itemmenuRepository = new GenericRepository<ItemMenu>(db);
                }
                return itemmenuRepository;
            }
        }
        public GenericRepository<Setting> SettingRepository
        {
            get
            {
                if (settingRepository == null)
                {
                    settingRepository = new GenericRepository<Setting>(db);
                }
                return settingRepository;
            }
        }
        public GenericRepository<Slider> SliderRepository
        {
            get
            {
                if (sliderRepository == null)
                {
                    sliderRepository = new GenericRepository<Slider>(db);
                }
                return sliderRepository;
            }
        }
        public GenericRepository<Social> SocialRepository
        {
            get
            {
                if (socialRepository == null)
                {
                    socialRepository = new GenericRepository<Social>(db);
                }
                return socialRepository;
            }
        }
        public GenericRepository<Brand> BrandRepository
        {
            get
            {
                if (brandRepository == null)
                {
                    brandRepository = new GenericRepository<Brand>(db);
                }
                return brandRepository;
            }
        }
        public GenericRepository<Advertise> AdvertiseRepository
        {
            get
            {
                if (advertiseRepository == null)
                {
                    advertiseRepository = new GenericRepository<Advertise>(db);
                }
                return advertiseRepository;
            }
        }
        public GenericRepository<UsualQuestion> UsualQuestionRepository
        {
            get
            {
                if (usualQuestionRepository == null)
                {
                    usualQuestionRepository = new GenericRepository<UsualQuestion>(db);
                }
                return usualQuestionRepository;
            }
        }
        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new GenericRepository<Comment>(db);
                }
                return commentRepository;
            }
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
