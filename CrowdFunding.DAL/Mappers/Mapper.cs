using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Reflection;
using CrowdFunding.DAL.Models;

namespace CrowdFunding.DAL.Mappers
{
    internal static class Mapper
    {
        private static void MatchAndMap<TDestination>(this IDataRecord source, TDestination destination)
            where TDestination : class, new()
        {
            if (source != null && destination != null)
            {
                //List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
                List<string> sourceProperties = new List<string>();

                for(int i = 0; i < source.FieldCount; i++)
                {
                    sourceProperties.Add(source.GetName(i));
                }

                List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

                foreach (string sourceProperty in sourceProperties)
                {
                    PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty);

                    if (destinationProperty != null)
                    {
                        try
                        {
                            //(reader[nameof(Movie.synopsis)] == DBNull.Value) ? null : (string)reader[nameof(Movie.synopsis)],
                            if(source[sourceProperty] == DBNull.Value)
                                destinationProperty.SetValue(destination,null, null);
                            else
                                destinationProperty.SetValue(destination, source[sourceProperty], null);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }

        }

        internal static TDestination MapTo<TDestination>(this IDataRecord mapSource)
            where TDestination : class, new()
        {
            var destination = Activator.CreateInstance<TDestination>();
            MatchAndMap(mapSource, destination);

            return destination;
        }

        //internal static Category ToCategory(this IDataRecord dataRecord)
        //{
        //    return new Category() 
        //    { 
        //        Id = (int)dataRecord["Id"], 
        //        Name = (string)dataRecord["Name"],
        //        Description = (string)dataRecord["Description"]
        //    };
        //}

        //internal static Project ToProject(this IDataRecord dataRecord)
        //{
        //    return new Project() 
        //    { 
        //        Id = (int)dataRecord["Id"], 
        //        Title = (string)dataRecord["Title"], 
        //        Description = (string)dataRecord["Description"],
        //        FundingCeiling = (decimal)dataRecord["FundingCeiling"],
                
        //    };
        //}
    }
}
