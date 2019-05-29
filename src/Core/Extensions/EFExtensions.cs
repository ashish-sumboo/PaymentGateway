//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;

//namespace Core.Extensions
//{
//    public static class EFExtensions
//    {
//        public static async System.Threading.Tasks.Task SaveChangesAsync2(this Microsoft.EntityFrameworkCore.DbContext context)
//        {
//            try
//            {
//                await context.SaveChangesAsync();
//            }
//            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
//            {
//                Exception inner = ex;
//                while (inner.InnerException != null)
//                {
//                    inner = inner.InnerException;
//                }

//                throw inner;
//            }
//            catch (DbEntityValidationException ex)
//            {
//                var message = ex.Message;

//                foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
//                {
//                    message += $"\n{dbEntityValidationResult.Entry.Entity}";
//                    message = dbEntityValidationResult.ValidationErrors
//                        .Aggregate(message, (current, dbValidationError) => current + $"\n{dbValidationError.PropertyName}: {dbValidationError.ErrorMessage}");
//                }

//                throw new Exception(message);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//    }
//}
