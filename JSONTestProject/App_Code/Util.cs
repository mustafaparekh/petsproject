using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

// Utility class
public class Util
{
	public Util()
	{
	}

    // Groups the gender (given in param) as first step and then calls methods for further processing
    public List<string> getDataForGenderGroup(JArray jsonCollection, string gender, string petTypeFilter)
    {
        List<JToken> genderData = jsonCollection.SelectTokens("$.[?(@.gender=='" + gender + "')]").ToList();
        return getPetsListForOwnerGender(genderData, petTypeFilter);
    }


    // Receives JToken Collection and compiles a filtered list of desired pet type against the people
    private List<string> getPetsListForOwnerGender(List<JToken> people, string petTypeFilter)
    {

        List<JToken> filteredPetsListForGender = new List<JToken>();  
      
        // Loop to filter each person's pets by its type 
        // and adding to the main Pet Collection for Gender
        foreach (JToken p in people)
        {
            // Do not process if there are no pets
            if (!p["pets"].HasValues)
            {
                continue;
            }

            // Filtering pets by type
            List<JToken> filteredPetsForPerson  = JArray.Parse(p["pets"].ToString())
                .SelectTokens("$.[?(@.type=='" + petTypeFilter + "')]").ToList();


            //forming single collection for ALL pets owned by a gender 
            filteredPetsListForGender.AddRange(filteredPetsForPerson); 
        }

        return getSortedPetNamesList(filteredPetsListForGender);
    }


    // Takes the JToken list, and returns a sorted string List
    private List<string> getSortedPetNamesList(List<JToken> petsCollection)
    {
        List<string> petNamesForGender = new List<string>();

        foreach (JToken pet in petsCollection)
        {
            petNamesForGender.Add(pet["name"].ToString());
        }

        petNamesForGender.Sort();

        return petNamesForGender;
    }


}