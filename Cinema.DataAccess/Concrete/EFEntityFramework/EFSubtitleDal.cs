using Cinema.Core.DataAccess.EntityFramework;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Contexts;
using Cinema.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Concrete.EFEntityFramework
{
    public class EFSubtitleDal:EfEntityRepositoryBase<Subtitle,CinemaDbContext>,ISubtitleDal
    {
    }
}
