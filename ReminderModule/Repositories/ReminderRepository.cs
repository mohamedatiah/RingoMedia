using ReminderModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderModule.Repositories
{


    public class ReminderRepository : Repository<Reminder>, IReminderRepository
    {
        public ReminderRepository(ReminderDbContext context) : base(context)
        {
        }
    }
    }
