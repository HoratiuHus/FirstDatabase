//using DataAccess.Data.Interfaces;
//using Microsoft.AspNetCore.Identity;

//namespace UsersApi
//{
//    public static class Api
//    {
//        public static void ConfigureApi(this WebApplication app)
//        {
//            app.MapGet(pattern: "/Users", GetUsers);
//            app.MapGet(pattern: "/Users/{id}", GetUser);
//            app.MapPost(pattern: "/Users", InsertUser);
//            app.MapPut(pattern: "/Users", UpdateUser);
//            app.MapDelete(pattern: "/Users", DeleteUser);
//        }

//        private static async Task<IResult> GetUsers(IUserData data)
//        {
//            try
//            {
//                return Results.Ok(await data.GetUsersAsync());
//            }
//            catch(Exception ex)
//            {
//                return Results.Problem(ex.Message);
//            }
//        }

//        private static async Task<IResult> GetUser(int id, IUserData data)
//        {
//            try
//            {
//                var results = await data.GetUserByIDAsync(id); 
//                if(results == null) return Results.NotFound();
//                return Results.Ok(results);
//            }
//            catch (Exception ex)
//            {
//                return Results.Problem(ex.Message);
//            }
//        }

//        private static async Task<IResult> InsertUser(User user, IUserData data)
//        {
//            try
//            {
//                await data.InsertUserAsync(user);
//                return Results.Ok();
//            }
//            catch (Exception ex)
//            {
//                return Results.Problem(ex.Message);
//            }   
//        }

//        private static async Task<IResult> UpdateUser(User user, IUserData data)
//        {
//            try
//            {
//                await data.UpdateUserAsync(user);
//                return Results.Ok();
//            }
//            catch (Exception ex)
//            {
//                return Results.Problem(ex.Message);
//            }
//        }

//        private static async Task<IResult> DeleteUser(int id, IUserData data)
//        {
//            try
//            {
//                await data.DeleteUserAsync(id);
//                return Results.Ok();
//            }
//            catch (Exception ex)
//            {
//                return Results.Problem(ex.Message);
//            }
//        }
//    }
//}
