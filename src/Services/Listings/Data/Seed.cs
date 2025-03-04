using Marten.Schema;

namespace Listings.Data;

public class Seed : IInitialData {
  public async Task Populate(IDocumentStore store, CancellationToken cancellation) {
    using (var session = store.LightweightSession()) {
      if (await session.Query<Listing>().AnyAsync()) return;

      session.Store<Listing>(GetInitialListings());
      await session.SaveChangesAsync(cancellation);
    }
  }

  private IEnumerable<Listing> GetInitialListings() {
    // FIXME: Add the actual data later
    return new List<Listing> {
      new Listing {
        Name = "Private room  in a 1 bed appartment",
        Description = "My apartment is light an airy with a balcony on each side of the building.  I have furnished the apartment slowly with furniture I have chose to give a homely and welcome feel.  The apartment is in a quiet area close to a park and local shops.",
        Country = "Switzerland",
        City = "Genève",
        State = "Genève",
        Street = "Avenue de France, Genève, Genève 1202, Switzerland",
        BedroomNumber = 2,
        BathroomNumber = 1,
        KitchenNumber = 1,
        Amenities = new List<string> {
          "TV",
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Kitchen",
          "Buzzer/Wireless Intercom",
          "Heating",
          "Family/Kid Friendly",
          "Suitable for Events",
          "Washer",
          "Essentials",
          "Shampoo",
          "Hangers",
          "Hair Dryer",
          "Iron",
          "Laptop Friendly Workspace"
        },
        Category = Category.Apartment,
        Price = 200M,
        Image = "https://a2.muscache.com/im/pictures/f7936be5-06d0-411d-8eb0-9f2154bf631d.jpg?aki_policy=x_large",
        CoordinateLat = 46.188721636995275M,
        CoordinateLong = 6.154815921366351M,
        CreatedAt = new DateTime(2024, 1, 23),
        UpdatedAt = new DateTime(2024, 1, 23)
      },
      new Listing {
        Name = "Superbe attique au centre de Genève",
        Description = "Superbe appartement attique lumineux (5ème étage) dans le quartier branché de Genève (Plainpalais). Pas d'ascenseur. Accès facile aux commerces et transports.",
        Country = "Switzerland",
        City = "Genève",
        State = "Genève",
        Street = "Rue de l'Ecole-de-Médecine, Genève, Genève 1205, Switzerland",
        BedroomNumber = 2,
        BathroomNumber = 2,
        KitchenNumber = 1,
        Amenities = new List<string> {
          "TV",
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Kitchen",
          "Buzzer/Wireless Intercom",
          "Heating",
          "Family/Kid Friendly",
          "Suitable for Events",
          "Washer",
          "Essentials",
          "Shampoo",
          "Hangers",
          "Hair Dryer",
          "Iron",
          "Laptop Friendly Workspace"
        },
        Category = Category.Apartment,
        Price = 220.35M,
        Image = "https://a1.muscache.com/im/pictures/93106375/3102df64_original.jpg?aki_policy=x_large",
        CoordinateLat = 46.19623752047105M,
        CoordinateLong = 6.1393404129302676M,
        Notice = "No Pets Apartment!",
        CreatedAt = new DateTime(2024, 2, 8),
        UpdatedAt = new DateTime(2024, 2, 8)
      },
      new Listing {
        Name = "Résidence de France",
        Description = "Apparement meuble en Attique de 100m2 Deux chambres à coucher Deux belles terrasses Vue imprenable sur le lac léman Entièrement rénové WIFI/Cablé/TV Sécurisé par caméra",
        Country = "Switzerland",
        City = "Genève",
        State = "Genève",
        Street = "Avenue de France, Genève, Genève 1202, Switzerland",
        BedroomNumber = 2,
        BathroomNumber = 1,
        KitchenNumber = 0,
        Amenities = new List<string> {
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Air Conditioning",
          "Kitchen",
          "Elevator in Building",
          "Buzzer/Wireless Intercom",
          "Heating",
          "Family/Kid Friendly",
          "Smoke Detector",
          "Safety Card",
          "Fire Extinguisher",
          "24-Hour Check-in"
        },
        Category = Category.Apartment,
        Price = 270M,
        Image = "https://a2.muscache.com/im/pictures/8ab7ea96-eb70-41f7-91eb-a18f55f51e3b.jpg?aki_policy=x_large",
        CoordinateLong = 6.149711531451913M,
        CoordinateLat = 46.21892208446671M,
        CreatedAt = new DateTime(2024, 2, 1),
        UpdatedAt = new DateTime(2024, 2, 1)
      },
      new Listing {
        Name = "Quiet House with Swimming pool",
        Description = "Near the Geneva Lake (5minutes by foot) and Near downtown Geneva (7kilometers), our house is in a very quiet area.",
        Country = "Switzerland",
        City = "Genève",
        State = "Genève",
        Street = "Avenue de France, Genève, Genève 1202, Switzerland",
        BedroomNumber = 3,
        BathroomNumber = 3,
        KitchenNumber = 1,
        Amenities = new List<string> {
          "TV",
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Wheelchair Accessible",
          "Pool",
          "Kitchen",
          "Free Parking on Premises",
          "Indoor Fireplace",
          "Heating",
          "Family/Kid Friendly",
          "Washer",
          "Dryer",
          "Fire Extinguisher",
          "Essentials",
          "Shampoo",
          "24-Hour Check-in",
          "Hangers",
          "Hair Dryer",
          "Iron",
          "Laptop Friendly Workspace"
        },
        Category = Category.Apartment,
        Price = 400M,
        Image = "https://a2.muscache.com/im/pictures/821866f0-e5b4-4303-98da-e6b23aeb8da4.jpg?aki_policy=x_large",
        CoordinateLong = 6.202518183588441M,
        CoordinateLat = 46.24620198568888M,
        CreatedAt = new DateTime(2023, 12, 13),
        UpdatedAt = new DateTime(2023, 12, 13)
      },
      new Listing {
        Name = "Cozy Room with Private bathroom",
        Description = "We offer a cozy private room with a comfortable mattress, private shower and WC, in our newly refurbished 130sqm flat.",
        Country = "Switzerland",
        City = "Grand-Lancy",
        State = "Genève",
        Street = "Grand-Lancy, Geneva 1212, Switzerland",
        BedroomNumber = 1,
        BathroomNumber = 1,
        KitchenNumber = 0,
        Amenities = new List<string> {
           "TV",
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Kitchen",
          "Elevator in Building",
          "Heating",
          "Washer",
          "Dryer",
          "First Aid Kit",
          "Essentials",
          "Shampoo"
        },
        Category = Category.Apartment,
        Price = 66M,
        Image = "https://a0.muscache.com/im/pictures/84508134/4bd2ac1b_original.jpg?aki_policy=x_large",
        CoordinateLong = 6.120306266409345M,
        CoordinateLat = 46.17419538191277M,
        CreatedAt = new DateTime(2024, 2, 21),
        UpdatedAt = new DateTime(2024, 2, 21)
      },
      new Listing {
        Name = "Central nice&cosy room by the lake",
        Description = "Sunny room, fully furnished, 10 sqm including wardrobe, desk, single bed, balcony,  armchair,...",
        Country = "Switzerland",
        City = "Geneva",
        State = "Genève",
        Street = "Rue des Eaux-Vives, Genève, Genève 1207, Switzerland",
        BedroomNumber = 1,
        BathroomNumber = 1,
        KitchenNumber = 1,
        Amenities = new List<string> {
         "TV",
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Kitchen",
          "Elevator in Building",
          "Heating",
          "Washer",
          "Dryer",
          "Essentials",
          "Shampoo",
          "24-Hour Check-in",
          "Hangers",
          "Hair Dryer",
          "Iron",
          "Laptop Friendly Workspace"
        },
        Category = Category.Apartment,
        Price = 49M,
        Image = "https://a2.muscache.com/im/pictures/044a6d90-a268-4ed3-a609-74a9ecd0e9e4.jpg?aki_policy=x_large",
        CoordinateLong = 6.158288735702611M,
        CoordinateLat = 46.20407766980833M,
        Notice = "No Pets Apartment!",
        CreatedAt = new DateTime(2024, 3, 23),
        UpdatedAt = new DateTime(2024, 3, 23)
      },
      new Listing {
        Name = "Apartment close to Gare Cornavin",
        Description = "Superb Apartment 2 minutes walking to Gare Cornavin. Ideally located between \"Rue des Alpes\" and \"Rue du Mont-Blanc\". Capacity for 4 People, one big bedroom and one big sofa bed.",
        Country = "Switzerland",
        City = "Geneva",
        State = "Genève",
        Street = "Rue Pradier, Genève, Genève 1201, Switzerland",
        BedroomNumber = 1,
        BathroomNumber = 1,
        KitchenNumber = 1,
        Amenities = new List<string> {
         "TV",
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Kitchen",
          "Elevator in Building",
          "Heating",
          "Washer",
          "Dryer",
          "Essentials",
          "Shampoo",
          "24-Hour Check-in",
          "Hangers",
          "Hair Dryer",
          "Iron",
          "Laptop Friendly Workspace"
        },
        Category = Category.Apartment,
        Price = 119M,
        Image = "https://a2.muscache.com/im/pictures/5a2773b3-56c1-4f6a-84ba-87ea5d835109.jpg?aki_policy=x_large",
        CoordinateLong = 6.143712401368743M,
        CoordinateLat = 46.21075115254551M,
        CreatedAt = new DateTime(2024, 1, 12),
        UpdatedAt = new DateTime(2024, 1, 12)
      },
      new Listing {
        Name = "Perfect for UN Intern ! Female only",
        Description = "Perfect for an UN Intern !! 20 min from United Nations, Geneva Airport.. Our beautiful and spacious apartment is located in Eaux-Vives, the best area in Geneva! Panoramic view of the famous Water Jet. Everything is in walking distance, lake in 5 mins",
        Country = "Switzerland",
        City = "Geneva",
        State = "Genève",
        Street = "Rue des Vollandes, Geneva, Geneva 1207, Switzerland",
        BedroomNumber = 1,
        BathroomNumber = 1,
        KitchenNumber = 1,
        Amenities = new List<string> {
         "TV",
          "Cable TV",
          "Internet",
          "Wireless Internet",
          "Kitchen",
          "Elevator in Building",
          "Heating",
          "Washer",
          "Dryer",
          "First Aid Kit",
          "Fire Extinguisher",
          "Essentials",
          "Shampoo",
          "24-Hour Check-in",
          "Hangers",
          "Hair Dryer",
          "Iron",
          "Laptop Friendly Workspace"
        },
        Category = Category.Apartment,
        Price = 55M,
        Image = "https://a2.muscache.com/im/pictures/3c0d6ee8-5fa4-4a1e-9be0-3d8921d7d6df.jpg?aki_policy=x_large",
        CoordinateLong = 6.160471926508294M,
        CoordinateLat = 46.20288485185194M,
        Notice = "Female Only!!!",
        CreatedAt = new DateTime(2023, 11, 16),
        UpdatedAt = new DateTime(2023, 11, 16)
      },
    };
  }
}
