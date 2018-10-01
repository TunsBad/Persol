using Npgsql;
using NpgsqlTypes;
using Persol.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Persol
{
    public class DbHelper
    {
        private static readonly string _dBConn = ConfigurationManager.AppSettings["CONNECTION_STRING"];
        public static DbHelper Instance = new DbHelper();
        
        public List<Car> GetCars()
        {
            var con = new NpgsqlConnection(_dBConn);
            List<Car> cars = new List<Car>() { };

            var command = new NpgsqlCommand("\"getCars\"", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            con.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                cars.Add(new Car
                {
                    Id = reader.GetFieldValue<int>(0),
                    Name = reader.GetFieldValue<string>(1),
                    Make = reader.GetFieldValue<string>(2),
                    Year = reader.GetFieldValue<string>(3),
                    Model = reader.GetFieldValue<string>(4)
                });
            }
            con.Close();
            con.Dispose();

            return cars;

        }

        public Car GetCar(int carid)
        {
            var con = new NpgsqlConnection(_dBConn);
            List<Car> car = new List<Car>() { };

            var command = new NpgsqlCommand("\"getCar\"", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
            command.Parameters[0].Value = carid;

            con.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                car.Add(new Car
                {
                    Id = reader.GetFieldValue<int>(0),
                    Name = reader.GetFieldValue<string>(1),
                    Make = reader.GetFieldValue<string>(2),
                    Year = reader.GetFieldValue<string>(3),
                    Model = reader.GetFieldValue<string>(4)
                });
            }
            con.Close();
            con.Dispose();

            return car.SingleOrDefault();

        }

        public int StoreCar(Car car)
        {
            var con = new NpgsqlConnection(_dBConn);
            int result;

            var command = new NpgsqlCommand("\"storeCar\"", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Text));
            command.Parameters.Add(new NpgsqlParameter("make", NpgsqlDbType.Text));
            command.Parameters.Add(new NpgsqlParameter("year", NpgsqlDbType.Text));
            command.Parameters.Add(new NpgsqlParameter("model", NpgsqlDbType.Text));

            command.Parameters[0].Value = car.Name;
            command.Parameters[1].Value = car.Make;
            command.Parameters[2].Value = car.Year;
            command.Parameters[3].Value = car.Model;

            con.Open();
            result = Convert.ToInt32(command.ExecuteScalar());

            con.Close();
            con.Dispose();

            return result;
        }

        public int UpdateCar(Car car)
        {
            var con = new NpgsqlConnection(_dBConn);
            int result;

            var command = new NpgsqlCommand("\"updateCar\"", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            command.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Text));
            command.Parameters.Add(new NpgsqlParameter("make", NpgsqlDbType.Text));
            command.Parameters.Add(new NpgsqlParameter("year", NpgsqlDbType.Text));
            command.Parameters.Add(new NpgsqlParameter("model", NpgsqlDbType.Text));

            command.Parameters[0].Value = car.Id;
            command.Parameters[1].Value = car.Name;
            command.Parameters[2].Value = car.Make;
            command.Parameters[3].Value = car.Year;
            command.Parameters[4].Value = car.Model;

            con.Open();
            result = Convert.ToInt32(command.ExecuteScalar());

            con.Close();
            con.Dispose();

            return result;
        }

        public int DeleteCar(int carid)
        {
            var con = new NpgsqlConnection(_dBConn);
            int result;

            var command = new NpgsqlCommand("\"deleteCar\"", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
            command.Parameters[0].Value = carid;

            con.Open();
            result = Convert.ToInt32(command.ExecuteScalar());

            con.Close();
            con.Dispose();

            return result;
        }
    }
}