//LANGUAGE
public static class LANGUAGE {

    public static int CUR_LANG = EncryptedPlayerPrefs.GetInt("language", 0);
    public static void SET_LANGUAGE(int LANG) {
        EncryptedPlayerPrefs.SetInt("language", LANG);
        CUR_LANG = LANG;
        CONSTANTS.SET_AGE_NAMES(LANG);
        Data.LastPlayed = (System.DateTime.Now.Ticks / 10000000).ToString();
        SaveGameController.instance.saveGame();

        Data.RESET();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public static void SET_LANGUAGE_OPENING(int LANG) {
        EncryptedPlayerPrefs.SetInt("language", LANG);
        CUR_LANG = LANG;
        CONSTANTS.SET_AGE_NAMES(LANG);
    }

    //CONSTANTS
    public static string[] AGE_NAMES_ENGLISH = { "Stone Age: Tundra", "Stone Age: Desert", "Stone Age: Forest",
                                                    "Copper Age: Cave", "Copper Age: Night", "Copper Age: Mountains",
                                                    "Iron Age: Forest", "Iron Age: Moderate", "Iron Age: Valley"};
    public static string[] AGE_NAMES_GERMAN = { "Steinzeit: Tundra", "Steinzeit: Wüste", "Steinzeit: Wald",
                                                    "Kupferzeit: Höhle", "Kupferzeit: Nacht", "Kupferzeit: Gebirge",
                                                    "Eisenzeit: Wald", "Eisenzeit: Gemäßigt", "Eisenzeit: Tal"};
    public static string[][] AGE_NAMES = { AGE_NAMES_ENGLISH, AGE_NAMES_GERMAN };
    public static string[] SECONDS_TO_STRING_HOURS = { "{0} hours", "{0} Stunden" };
    public static string[] SECONDS_TO_STRING_HOUR = { "{0} hour", "{0} Stunde" };
    public static string[] SECONDS_TO_STRING_MINUTES = { "{0} minutes", "{0} Minuten" };
    public static string[] SECONDS_TO_STRING_MINUTE = { "{0} minute", "{0} Minute" };
    public static string[] SECONDS_TO_STRING_SECONDS = { "{0} seconds", "{0} Sekunden" };
    public static string[] SECONDS_TO_STRING_SECOND = { "{0} second", "{0} Sekunde" };

    //ADS
    public static string[] AD_TRIGGER = { "Watch ad to get a random bonus?", "Werbung anschauen um einen zufälligen Bonus zu erhalten?" };
    public static string[] AD_GOLDCHEST = { "Goldchest received!", "Goldkiste erhalten!" };
    public static string[] AD_SILVERCHEST = { "Silverchest received!", "Silberkiste erhalten!" };
    public static string[] AD_BRONZECHEST = { "Bronzechest received!", "Bronzekiste erhalten!" };
    public static string[] AD_BONUS = { "Ad bonus!", "Werbebonus!" };
    public static string[] AD_CHESTTIME = { "Chesttime reduced by 3 hours!", "Kistenzeit um 3 Stunden verringert!" };

    //PURCHASER
    public static string[] P_THANKS = { "Have fun!", "Viel Spaß damit!" };

    //GAMECONTROLLER
    public static string[] GC_NOTIFICATION_GOLD = { "Goldchest", "Goldkiste" };
    public static string[] GC_NOTIFICATION_GOLD_LONG = { "Open your goldchest now!", "Öffne deine Goldkiste jetzt!" };
    public static string[] GC_NOTIFICATION_SILVER = { "Silverchest", "Silberkiste" };
    public static string[] GC_NOTIFICATION_SILVER_LONG = { "Open your silverchest now!", "Öffne deine Silberiste jetzt!" };
    public static string[] GC_NOTIFICATION_BRONZE = { "Bronzechest", "Bronzekiste" };
    public static string[] GC_NOTIFICATION_BRONZE_LONG = { "Open your bronzechest now!", "Öffne deine Bronzekiste jetzt!" };

    //GUICONTROLLER
    public static string[] GUI_SHOP = { "Epoch {0}, Stage {1}", "Epoche {0}, Abschnitt {1}" };
    public static string[] GUI_NEXTLEVEL_NO = { "No next era!", "Kein nächstes Zeitalter!" };
    public static string[] GUI_NEXTLEVEL_YES = { "Next era:\n{0}", "Nächstes Zeitalter:\n{0}" };
    public static string[] GUI_CHEST_WAIT = { "Wait!", "Warten!" };
    public static string[] GUI_CHEST_OPEN = { "Open!", "Öffnen!" };
    public static string[] GUI_WEAPON_CURRENT = { "Weapon (+{0}%)", "Waffe (+{0}%)" };
    public static string[] GUI_ARMOR_CURRENT = { "Armor (+{0}%)", "Rüstung (+{0}%)" };
    public static string[] GUI_PASSIVEMOVEMENT_CURRENT = { "Movement (+{0}%)", "Bewegung (+{0}%)" };
    public static string[] GUI_SETTINGS_HEADER = { "Settings", "Einstellungen" };
    public static string[] GUI_SETTINGS_LANGUAGE = { "Deutsch", "English" };
    public static string[] GUI_SETTINGS_DELETE = { "Delete savegame?", "Spielstand löschen?" };
    public static string[] GUI_STORAGE_HEADER = { "Storage", "Lager" };
    public static string[] GUI_BRONZE_HEADER = { "Bronzechest", "Bronzekiste" };
    public static string[] GUI_BRONZE_TEXT = { "A care package for you!", "Ein Care-Paket für dich!" };
    public static string[] GUI_SILVER_HEADER = { "Silverchest", "Silberkiste" };
    public static string[] GUI_SILVER_TEXT = { "You deserved it!", "Du verdienst es!" };
    public static string[] GUI_GOLD_HEADER = { "Goldchest", "Goldkiste" };
    public static string[] GUI_GOLD_TEXT = { "The rest of the world envys you!", "Purer Neid beim Rest der Welt!" };
    public static string[] GUI_WEAPON_HEADER = { "Weapon", "Waffe" };
    public static string[] GUI_WEAPON_TEXT = { "A weapon is really dangerous!", "Eine Waffe ist sehr gefährlich!" };
    public static string[] GUI_ARMOR_HEADER = { "Armor", "Rüstung" };
    public static string[] GUI_ARMOR_TEXT = { "An armor is really heavy!", "Eine Rüstung ist sehr schwer!" };
    public static string[] GUI_STATUS_POINT = { "Pointbonus", "Energiebonus" };
    public static string[] GUI_STATUS_GEM = { "Kyanitbonus", "Kyanitbonus" };
    public static string[] GUI_STATUS_CHESTTIME = { "Chesttime reduction", "Kistenzeitreduktion" };
    public static string[] GUI_STATUS_BRAVE = { "Braveness", "Tapferkeit" };
    public static string[] GUI_STATUS_AWESOME = { "Awesomeness", "Großartigkeit" };
    public static string[] GUI_STATUS_WISDOM = { "Wisdom", "Weisheit" };
    public static string[] GUI_BOOSTER_0 = { "5% of epoch - 15 Kyanit", "5% der Epoche - 15 Kyanit" };
    public static string[] GUI_BOOSTER_1 = { "10% of epoch - 30 Kyanit", "10% der Epoche - 30 Kyanit" };
    public static string[] GUI_BOOSTER_2 = { "25% of epoch - 75 Kyanit", "25% der Epoche - 75 Kyanit" };
    public static string[] GUI_BOOSTER_3 = { "50% of epoch - 150 Kyanit", "50% der Epoche - 150 Kyanit" };
    public static string[] GUI_NOTIFICATION_OK = { "Nice!", "Super!" };
    public static string[] GUI_NOTIFICATION_YES = { "Absolutely!", "Auf jeden Fall!" };
    public static string[] GUI_NOTIFICATION_NO = { "No, thanks!", "Nein, Danke!" };

    //SAVEGAMECONTROLLER
    public static string[] SGC_DELETE_1 = { "Do you really want to delete your savegame?", "Willst du deinen Speicherstand wirklich löschen?" };
    public static string[] SGC_DELETE_2 = { "Any progress will be lost!", "Dadurch geht jeglicher Fortschritt verloren!" };

    //STORAGECONTROLLER
    public static string[] SC_GEM = { "{0} Kyanit received!", "{0} Kyanit erhalten!" };
    public static string[] SC_POINTS = { "{0} Energy received!", "{0} Energie erhalten!" };
    public static string[] SC_CHESTREDUCTION = { "1% Chesttime reduction received!", "1% Kistenzeitreduktion erhalten!" };
    public static string[] SC_BRAVE = { "1% Braveness received!", "1% Tapferkeit erhalten!" };
    public static string[] SC_AWESOME = { "1% Awesomeness received!", "1% Großartigkeit erhalten!" };
    public static string[] SC_WISDOM = { "1% Wisdom received!", "1% Weisheit erhalten!" };
    public static string[] SC_WEAPON = { "New weapon received!", "Neue Waffe erhalten!" };
    public static string[] SC_ARMOR = { "New Armor received!", "Neue Rüstung erhalten!" };
    public static string[] SC_PASSIVEMOVEMENT = { "Passive Movement received!", "Passive Bewegung erhalten!" };
    public static string[] SC_BRONZE_FOUND = { "Bronzechest found!", "Bronzekiste gefunden!" };
    public static string[] SC_SILVER_FOUND = { "Silverchest found!", "Silberkiste gefunden!" };
    public static string[] SC_GOLD_FOUND = { "Goldchest found!", "Goldkiste gefunden!" };
    public static string[] SC_BRONZE_BUY = { "Do you want to use Kyanit to open the bronzechest?", "Willst du Kyanit benutzen um die Bronzekiste zu öffnen?" };
    public static string[] SC_SILVER_BUY = { "Do you want to use Kyanit to open the silverchest?", "Willst du Kyanit benutzen um die Silberkiste zu öffnen?" };
    public static string[] SC_GOLD_BUY = { "Do you want to use Kyanit to open the goldchest?", "Willst du Kyanit benutzen um die Goldkiste zu öffnen?" };

    public static string[] SC_WEAPON_ENGLISH = { "A spear is a stick with a stone.", "A boomerang boomerangs more than once.", "An extended arm for every knight, mosfortune for everyone else.",
                                                    "You can chop more than just trees with it.", "Don't worry, you won't run out of these."};
    public static string[] SC_WEAPON_GERMAN = { "Der Speer ist ein Stock mit einem Stein.", "Der Bumerang kommt nicht nur einmal.", "Eine verlängerter Arm für jeden Ritter, Pech für alle anderen.",
                                                    "Du kannst damit auch Bäume fällen.", "Keine Sorge, wie in jedem Film, werden sie dir nicht ausgehen."};
    public static string[][] SC_WEAPON_TEXT = { SC_WEAPON_ENGLISH, SC_WEAPON_GERMAN };
    public static string[] SC_WEAPON_UPGRADE = { "Do you want to upgrade your weapon?", "Willst du deine Waffe upgraden?" };
    public static string[] SC_WEAPON_BONUS = { "Your bonus on Energy is now {0}%!", "Dein Bonus auf Energie beträgt nun {0}%!" };

    public static string[] SC_ARMOR_ENGLISH = { "Designed by Adam.", "A luxury good right from the Stone Age", "The Cape is used. It belonged to Clarke Kent.",
                                                    "The basic idea originates from a turtoise.", "This mask makes you nearly invisible."};
    public static string[] SC_ARMOR_GERMAN = { "Designed by Adam.", "Ein Luxusartikel der Steinzeit.", "Das Cape ist gebraucht. Zuvor gehörte es Clarke Kent.",
                                                    "Die Idee dahinter stammt von einer Schildkröte.", "Die Maske macht dich fast unsichtbar."};
    public static string[][] SC_ARMOR_TEXT = { SC_ARMOR_ENGLISH, SC_ARMOR_GERMAN };
    public static string[] SC_ARMOR_UPGRADE = { "Do you want to upgrade your armor?", "Willst du deine Rüstung upgraden?" };
    public static string[] SC_ARMOR_BONUS = { "Your bonus on Kyanit is now {0}%!", "Dein Bonus auf Kyanit beträgt nun {0}%!" };


    //Neuen Text einfügen
    public static string[] SC_PASSIVEMOVEMENT_ENGLISH = { "A spear is a stick with a stone.", "A boomerang boomerangs more than once.", "An extended arm for every knight, mosfortune for everyone else.",
                                                    "You can chop more than just trees with it.", "Don't worry, you won't run out of these."};
    public static string[] SC_PASSIVEMOVEMENT_GERMAN = { "Der Speer ist ein Stock mit einem Stein.", "Der Bumerang kommt nicht nur einmal.", "Eine verlängerter Arm für jeden Ritter, Pech für alle anderen.",
                                                    "Du kannst damit auch Bäume fällen.", "Keine Sorge, wie in jedem Film, werden sie dir nicht ausgehen."};
    public static string[][] SC_PASSIVEMOVEMENT_TEXT = { SC_PASSIVEMOVEMENT_ENGLISH, SC_PASSIVEMOVEMENT_GERMAN };

    public static string[] SC_PASSIVEMOVEMENT_UPGRADE = { "Do you want to get passive movement?", "Willst du passive Bewegung erhalten?" };
    public static string[] SC_PASSIVEMOVEMENT_BONUS = { "You will move automaticly!", "Du bewegst dich nun automatisch!" };

    //STORECONTROLLER
    public static string[] S_BOOSTER_BUY = { "Do yout want to buy this booster?", "Willst du den Booster kaufen?" };
    public static string[] S_BOOSTER_0_YES = { "5% of the epoch skipped!", "5% der Epoche übersprungen!" };
    public static string[] S_BOOSTER_0_NO = { "You already reached the final epoch!", "Letzte Epoche bereits erreicht!" };
    public static string[] S_BOOSTER_1_YES = { "10% of the epoch skipped!", "10% der Epoche übersprungen!" };
    public static string[] S_BOOSTER_1_NO = { "You already reached the final epoch!", "Letzte Epoche bereits erreicht!" };
    public static string[] S_BOOSTER_2_YES = { "25% of the epoch skipped!", "25% der Epoche übersprungen!" };
    public static string[] S_BOOSTER_2_NO = { "You already reached the final epoch!", "Letzte Epoche bereits erreicht!" };
    public static string[] S_BOOSTER_3_YES = { "50% of the epoch skipped!", "50% der Epoche übersprungen!" };
    public static string[] S_BOOSTER_3_NO = { "You already reached the final epoch!", "Letzte Epoche bereits erreicht!" };

    //MISC
    public static string[] MISC_GEM = { "{0} Kyanit received!", "{0} Kyanit erhalten!" };
    public static string[] MISC_NO_GEM_1 = { "Not enough Kyanit", "Nicht genug Kyanit!" };
    public static string[] MISC_NO_GEM_2 = { "Do you want to buy some?", "Möchtest du welches kaufen?" };

    //OPENING
    public static string[] OPENING_ENGLISH = { "Hello, I am the natural scientist Charles D.", "I want you to prove my theories on human evolution.",
                                                "For this purpose I created a time machine which will send you chronological through the epochs of mankind.",
                                                "Are you ready for an adventure?", "The time machine has enough energy for one use.",
                                                "Run to collect energy.", "Very simple, isn't it?",
                                                "We'll be in continous contact", "You'll get a timebox from me regulary.",
                                                "Furthermore I'll gift you 50 Kyanit.", "These precious gems are accept as currency everywhere.",
                                                "You can find and trade more Kyanit on your adventure.", "Are you ready for your adventure?"};
    public static string[] OPENING_GERMAN = { "Hallo, ich bin der Naturforscher Charles D.", "Ich möchte, dass du meine Theorien zur menschlichen Evolution belegst.",
                                                "Ich habe eine Zeitmaschine entwickelt, die dich chronologisch in die verschiedensten Epochen der Menschheit schickt.",
                                                "Hast du schon Lust auf dein Abenteuer?", "Die Zeitmaschine hat nur genug Energie für einen Sprung.",
                                                "Du sammelst Energie, indem du rennst.", "Klingt einleuchtend, oder etwa nicht?",
                                                "Wir werden in ständigem Kontakt stehen.", "Du bekommst von mir regelmäßig eine Timebox zugeschickt, die dir weiterhelfen wird.",
                                                "Ich schenke dir zusätzlich noch 50 Kyanit.", "Diese seltenen Edelsteine werden überall als Währung akzeptiert.",
                                                "Weiteres Kyanit kannst du auf deinem Weg einsammeln oder eintauschen.", "Bist du bereit für dein Abenteuer?"};
    public static string[][] OPENING = { OPENING_ENGLISH, OPENING_GERMAN };
    public static string[] OPENING_CONTINUE_1_ENGLISH = { "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!", "Continue!" };
    public static string[] OPENING_CONTINUE_1_GERMAN = { "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!", "Weiter!" };
    public static string[] OPENING_CONTINUE_2_ENGLISH = { "What?!", "What?!", "What?!", "What?!", "What?!", "What?!", "What?!", "What?!", "What?!", "What?!", "What?!", "What?!", "What?!" };
    public static string[] OPENING_CONTINUE_2_GERMAN = { "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!", "Was?!" };
    public static string[][] OPENING_CONTINUE_1 = { OPENING_CONTINUE_1_ENGLISH, OPENING_CONTINUE_1_GERMAN };
    public static string[][] OPENING_CONTINUE_2 = { OPENING_CONTINUE_2_ENGLISH, OPENING_CONTINUE_2_GERMAN };
    public static string[] OPENING_WELCOME_BACK = { "Welcome back!", "Willkommen zurück!" };
}
