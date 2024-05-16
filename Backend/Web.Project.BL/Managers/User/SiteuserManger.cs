using FinalProject.Dal;
using FinalProject.Dal.Models;
public class UserManger : IUserManger
    {
        public IUnitofWork Unitofwork { get; }

        public UserManger(IUnitofWork userRepos)
        {
            this.Unitofwork = userRepos;
        }

        public User RegisterUser(UserAddDTO userAdd)
        {
            return new()
            {
                UserName = userAdd.UserName,
                PhoneNumber = userAdd.Phone,
                Email = userAdd.Email,
            };
        }

        public List<UserReadDto> GetAllAdmins()
        {
            List<UserReadDto> us = Unitofwork.UserRepo.GetAllAdmins().Select(i => new UserReadDto
            {
                Id= i.Id,
                UserName = i.UserName,
                Phone = i.PhoneNumber,
                Email = i.Email
            }).ToList();
            return us;
        }

        public List<UserReadDto> GetAllUsers()
        {
            List<UserReadDto> us = Unitofwork.UserRepo.GetAllUsers().Select(i => new UserReadDto
            {
                Id = i.Id,
                UserName = i.UserName,
                Phone = i.PhoneNumber,
                Email = i.Email
            }).ToList();
            return us;
        }

        public List<UserReadDto> GetAll()
        {
            List<UserReadDto> us = Unitofwork.UserRepo.GetAll().Select(i => new UserReadDto
            {
                Id = i.Id,
                UserName = i.UserName,
                Phone = i.PhoneNumber,
                Email = i.Email
            }).ToList();
            return us;
        }

        public UserDetailsDTO GetUserDetails(string id)
        {
            User s = Unitofwork.UserRepo.GeUserDetailsbyId(id);
            UserDetailsDTO user = new UserDetailsDTO()
            {
                UserName = s.UserName,
                Phone = s.PhoneNumber,
                Email = s.Email,
                Location = s.Location,
               
                Bookmarks = s.Bookmarks.Select(
                    i => new UserChildBookmarkDTO()
                    {
                        ServiceId = i.ServiceId,
                        ServiceName = i.Service.Name
                    }
                    ).ToList(),
                Notifications = s.Notifications.Select(
                    i => new UserChildNotificationDTO()
                    {
                        Id = i.Id,
                        Text = i.Text,
                        date = i.date,
                        seen = i.seen
                    }).ToList(),
                Ratings = s.Ratings.Select(
                    i => new UserChildRatingDTO()
                    {
                        ServiceId = i.ServiceId,
                        ServiceName = i.Service.Name,
                        Comment = i.Comment,
                        rating = i.rating,
                        date = i.date
                    }).ToList(),
                Services = s.Services.Select(
                    i => new UserChildServicesDTO()
                    {
                        Id = i.Id,
                        Approved = i.Approved,
                        Description = i.Description,
                        Location = i.Location,
                        Name = i.Name,
                        Price = i.Price,
                        Rating = i.Rating,
                    }
                    ).ToList(),
                ProviderRequests = Unitofwork.RequestRepo.GetbyProviderId(s.Id).Select(
                    i => new ProviderChildRequestDTO
                    {
                        Id = i.Id,
                        ServiceName = i.Service.Name,
                        ServiceId = i.ServiceId,
                        date = i.date,
                        Status=i.Status,
                        RequestText = i.RequestText,
                        RequesterName=Unitofwork.UserRepo.GetUserById(i.UserId).UserName
                    }
                    ).ToList(),
                UserRequests = Unitofwork.RequestRepo.GetbyUserId(s.Id).Select(
                    i => new UserChildRequestDTO
                    {
                        Id = i.Id,
                        ServiceName = i.Service.Name,
                        ServiceId = i.ServiceId,
                        date = i.date,
                        Status = i.Status,
                        RequestText = i.RequestText
                    }
                    ).ToList(),

            };
            return user;
        }

        public UserReadDto GetUser(string id)
        {
            User s = Unitofwork.UserRepo.GetUserById(id);
            return new() { Id = id, UserName = s.UserName, Phone = s.PhoneNumber, Email = s.Email };
        }

        public void UpateUserData(string id, UserUpdateDto User)
        {
            User s = Unitofwork.UserRepo.GetUserById(id);
            s.PhoneNumber = User.Phone;
            s.Email = User.Email;
            s.NormalizedEmail = s.Email.ToUpper();
            s.Location = User.Location;
            Unitofwork.UserRepo.Update(s);
            Unitofwork.SaveChanges();
        }

        public void AddBookmark(string UserID, int serviceID)
        {
            Unitofwork.BookmarkRepo.Add(new BookMark()
            { UserId = UserID, ServiceId = serviceID });
            Unitofwork.SaveChanges();
        }

        public void RemoveUser(string id)
        {
            User s = Unitofwork.UserRepo.GeUserDetailsbyId(id);
            Console.Write(s.UserName);
            if (s.Bookmarks.Count != 0)
            {
                List<BookMark> bookMarks = s.Bookmarks.ToList();
                foreach (BookMark book in bookMarks)
                {
                    Unitofwork.BookmarkRepo.RemoveEntity(book);
                }
            }
            if (s.UserRequests.Count != 0)
            {
                List<ServiceRequest> UserRequests = s.UserRequests.ToList();
                foreach (ServiceRequest serviceRequest in UserRequests)
                {
                    Unitofwork.RequestRepo.RemoveEntity(serviceRequest);
                }
            }
            if (s.Services.Count != 0)
            {
                List<Service> services = s.Services.ToList();

                foreach (Service service in services)
                {
                    if (service.Ratings.Count != 0)
                    {
                        List<Rating> ratings = service.Ratings.ToList();
                        foreach (Rating r in ratings)
                        {
                            Unitofwork.RatingRepo.RemoveEntity(r);
                        }
                    }
                    if (service.Requests.Count != 0)
                    {
                        List<ServiceRequest> UserRequests = service.Requests.ToList();
                        foreach (ServiceRequest serviceRequest in UserRequests)
                        {
                            Unitofwork.RequestRepo.RemoveEntity(serviceRequest);
                        }
                    }
                    Unitofwork.ServiceRepo.DeleteById(service.Id);
                }
            }
            if (s.Notifications.Count != 0)
            {
                List<Notification> notifications = s.Notifications.ToList();
                foreach (Notification notification in notifications)
                {
                    Unitofwork.NotificationRepo.RemoveEntity(notification);
                }
            }
            if (s.Ratings.Count != 0)
            {
                List<Rating> ratings = s.Ratings.ToList();
                foreach (Rating r in ratings)
                {
                    r.UserId = null;
                }
            }
            Unitofwork.UserRepo.RemoveEntity(s);
            Unitofwork.SaveChanges();
        }

        public void RemoveBookmark(string id, int serviceID)
        {
            BookMark bookMark = Unitofwork.BookmarkRepo.returnBookmark(id, serviceID);
            Unitofwork.BookmarkRepo.RemoveEntity(bookMark);
            Unitofwork.SaveChanges();
        }
    }
