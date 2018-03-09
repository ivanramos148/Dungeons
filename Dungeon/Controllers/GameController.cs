using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using Dungeon.Models;

namespace Dungeon.Controllers
{
    public class GameController : Controller
    {
        [HttpGet("/game")]

        public ActionResult Index()
        {
          // List<Room> allRooms = Room.GetAll();
          PC newPC = PC.Find(2);
          Console.WriteLine("in /game PC thinks its room # is: " + newPC.GetRoomId());

          Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
          Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
          //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
          myGame.Add("pc", PC.Find(newPC.GetId()));
          myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
          myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

          myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

          myMap = Game.GetMap();
          myGame.Add("map", myMap);
          myGame.Add("AllRooms", Room.GetAll());
          Console.WriteLine("Room inside /game is: " + Room.Find(newPC.GetRoomId()).GetName());

          return View("GameIndex", myGame);
        }

        [HttpGet("/game/room/{roomId}")]
        public ActionResult Move(int roomId)
        {
          string message = "";
          PC newPC = PC.Find(2);
          Room tempRoom = Room.Find(roomId);
          // if ( newPC.HasLight() )
          // {
              newPC.SetRoomId(roomId);
              newPC.Update(newPC.GetName(), newPC.GetPCType(), newPC.GetHP(), newPC.GetAC(), newPC.GetDamage(), newPC.GetLVL(), newPC.GetEXP(), newPC.GetRoomId());
              Console.WriteLine("newPC thinks its room is: " + newPC.GetRoomId());
          // }
          // else
          // {
          //     message="It's too dark to go that way";
          // }
          Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
          Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
          //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
          myGame.Add("pc", PC.Find(newPC.GetId()));
          myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
          myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

          myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

          myMap = Game.GetMap();
          myGame.Add("map", myMap);

          Console.WriteLine("Room inside Move is: " + Room.Find(newPC.GetRoomId()).GetName());
          Console.WriteLine("in Move PC thinks its room # is: " + newPC.GetRoomId());

          // if (message !=""){
          //     <APPEND MESSAGE>
          // }

          return View("GameIndex", myGame);
        }

        // [HttpGet("/game/look/{roomId}")]
        // public ActionResult Look(int roomId)
        // {
        //
        //     PC newPC = PC.Find(2);
        //     newPC.SetRoomId(roomId);
        //     Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
        //     Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
        //     //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
        //     myGame.Add("pc", PC.Find(newPC.GetId()));
        //     myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
        //     myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
        //
        //     myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
        //
        //     myMap = Game.GetMap();
        //     myGame.Add("map", myMap);
        //
        //     Console.WriteLine("Room inside Look is: " + Room.Find(newPC.GetRoomId()).GetName());
        //     Console.WriteLine("in Look PC thinks its room # is: " + newPC.GetRoomId());
        //
        //     return View("Look", myGame);
        // }


        [HttpGet("/game/look/{roomId}")]
        public ActionResult Look(int roomId)
        {

          PC newPC = PC.Find(2);
          newPC.SetRoomId(roomId);
          Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
          Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
          //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
          myGame.Add("pc", PC.Find(newPC.GetId()));
          myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
          myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

          myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

          myMap = Game.GetMap();
          myGame.Add("map", myMap);
          return View("Look", myGame);
        }

      // myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
      //
      // myMap = Game.GetMap();
      // myGame.Add("map", myMap);
      //
      //
      // return View("GameIndex", myGame);

    //
    // [HttpGet("/game/room/{roomId}")]
    // public ActionResult Move(int roomId)
    // {
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //   Console.WriteLine("Passed Room Id data is: " + roomId);
    //   Console.WriteLine("PC's new room is: " + newPC.GetRoomId());
    //   Console.WriteLine("Room Lighted is: " + Room.Find(newPC.GetRoomId()).GetLight());
    //   Console.WriteLine("Room Name is: " + Room.Find(newPC.GetRoomId()).GetName());
    //   Console.WriteLine("Room 2's Name is: " + Room.Find(2).GetName());
    //
    //
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myGame);
    //
    //
    //   // return View("/game");
    //   return View("GameIndex", myGame);
    //
    //
    // }

    // [HttpGet("/game/room/{roomId}")]
    // public ActionResult Move(int roomId)
    // {
    //
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myMap);
    //   return View("GameIndex", myGame);
    // }

    // [HttpGet("/game/room/{roomId}")]
    // public ActionResult Move(int roomId)
    // {
    //
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myMap);
    //   return View("GameIndex", myGame);
    // }

    // [HttpGet("/game/look/{roomId}")]
    // public ActionResult Look(int roomId)
    // {
    //
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myMap);
    //   return View("Look", myGame);
    // }

    [HttpGet("/game/inventory/{pcId}")]
    public ActionResult Inventory(int pcId)
    {

      PC newPC = PC.Find(2);
      List<Item> tempItems = newPC.GetItems();
      // newPC.SetRoomId(pcId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      myGame.Add("stuff", tempItems);

      return View("Inventory", myGame);
    }

   [HttpGet("/game/select/{roomId}")]
    public ActionResult Select(int roomId)
    {
      PC newPC = PC.Find(2);
      List<Item> newItem = newPC.GetItems();


      // newPC.SetRoomId(pcId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      myGame.Add("stuff", newItem);

      return View("Select", myGame);
    }

    [HttpGet("/game/select/{pcId}/{roomId}/{itemId}")]
    public ActionResult SelectItem(int pcId, int roomId, int itemId)
    {
      PC newPC = PC.Find(pcId);
      List<Item> newItem = newPC.GetItems();
      Item tempItem = Item.Find(itemId);
      newPC.AddItemToPC(Item.Find(itemId));
      tempItem.RemoveFromContents(itemId);

      // newPC.SetRoomId(pcId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      myGame.Add("stuff", newItem);

      return View("Select", myGame);
    }




    [HttpGet("/game/combat/{roomId}")]
    public ActionResult Combat(int roomId)
    {
      PC newPC = PC.Find(2);
      newPC.SetRoomId(roomId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      string[] message = new string[] {"","","","", "", ""};
      myGame.Add("message", message);


      return View("Fight", myGame);
    }

    [HttpGet("/game/combat/attack/{roomId}")]
    public ActionResult CombatAttack(int roomId)
    {
      string newView = "Fight";
      PC newPC = PC.Find(2);
      newPC.SetRoomId(roomId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      int[] THAC0 = new int[] {20, 20, 18, 18, 16, 16, 14, 14, 12, 12, 10, 10, 8, 8, 6, 6};
      int tempPCHP = newPC.GetHP();
      NPC tempNPC = Game.GetAllNPCs(newPC.GetRoomId())[0];
      int tempNPCHP = tempNPC.GetHP();
      int tempPCAC = newPC.GetAC();
      int tempNPCAC = tempNPC.GetAC();
      int tempPCDam = newPC.GetDamage();
      int tempNPCDam = tempNPC.GetDamage();
      bool youHit = false;
      bool itHits = false;
      int PCDamage = 0;
      int NPCDamage = 0;
      int yourRoll = Game.GetRandomNumber(1,20);
      if(yourRoll > 20 - tempNPC.GetAC())
      {
        youHit = true;
        PCDamage = Game.GetRandomNumber(1, tempPCDam);
        tempNPCHP = tempNPCHP - PCDamage;
        Console.WriteLine("PCDamage = " + PCDamage);
        Console.WriteLine("tempNPCHP = " + tempNPCHP);
        tempNPC.SetHP(tempNPCHP);
      }
      int itsRoll = Game.GetRandomNumber(1,20);
      if(itsRoll > 20 - newPC.GetAC())
      {
        itHits = true;
        NPCDamage = Game.GetRandomNumber(1, tempNPCDam);
        tempPCHP = tempPCHP - NPCDamage;
        Console.WriteLine("NPCDamage = " + NPCDamage);
        Console.WriteLine("newPCHP = " + tempPCHP);
        newPC.SetHP(tempPCHP);
      }
      string[] message = new string[] {"","","","", "", ""};

      newPC.Update(newPC.GetName(), newPC.GetPCType(), tempPCHP, 6, newPC.GetDamage(), newPC.GetLVL(), newPC.GetEXP(), newPC.GetRoomId());
      tempNPC.Update(tempNPC.GetName(), tempNPC.GetNPCType(), tempNPCHP, 10, tempNPC.GetDamage(), tempNPC.GetLVL(), tempNPC.GetRoomId());

      if (tempPCHP <=0)
      {
        newView="PCDiedInBattle";
      }
      else if (tempNPCHP <=0)
      {
        newView="NPCDiedInBattle";
        tempNPC.SetRoomId(0);
        tempNPC.Update(tempNPC.GetName(), tempNPC.GetNPCType(), tempNPCHP, tempNPC.GetAC(), tempNPC.GetDamage(), tempNPC.GetLVL(), -1);

      }
      else
      {
          message[0] = "You attack the " + tempNPC.GetName() + "\n";
          if (youHit) { message[1] = "You do " + PCDamage + " points of damage!!" + "\n"; } else { message[1] = "You miss it!"; }
          message[2] = "The " + tempNPC.GetName() + " attacks you back.\n";
          if (itHits) { message[3] = "It does " + NPCDamage + " points of damage to you!\n"; } else { message[3] = "It misses you!"; }
      }
      message[4]="You have " + tempPCHP + " Health Points.";
      message[5]="The " + tempNPC.GetName() + " has " + tempNPCHP + " Health Points.";




      // newPC.Update(newPC.GetName(), newPC.GetPCType(), tempPCHP, newPC.GetAC(), newPC.GetDamage(), newPC.GetLVL(), newPC.GetEXP(), newPC.GetRoomId());
      // tempNPC.Update(tempNPC.GetName(), tempNPC.GetNPCType(), tempNPCHP, tempNPC.GetAC(), tempNPC.GetDamage(), tempNPC.GetLVL(), tempNPC.GetRoomId());

      // int NPCThac0 = 20 - tempNPC.GetLVL();
      // int PCThac0 = THAC0[newPC.GetLVL()];
      // Console.WriteLine("PCThac0 = " + PCThac0);
      //
      // // Random rnd = new Random();
      // // int month = rnd.Next(1, 13); // creates a number between 1 and 12
      // // int dice = rnd.Next(1, 7);
      // int PCDamage = Game.GetRandomNumber(1,tempPCDam);
      // int NPCDamage = Game.GetRandomNumber(1,tempNPCDam);
      // int PCRoll = Game.GetRandomNumber(1,20);
      // Console.WriteLine("PCRoll = " + PCRoll);
      // int NPCRoll = Game.GetRandomNumber(1,20);
      // Console.WriteLine("NPCRoll = " + NPCRoll);
      //
      //
      // if (NPCRoll >= NPCThac0-newPC.GetAC() )
      // {
      //   tempPCHP = tempPCHP - NPCDamage;
      // };
      // if (PCRoll >= PCThac0-tempNPC.GetAC() )
      // {
      //   tempNPCHP = tempNPCHP - PCDamage;
      // };
      //
      // // newPC.SetHP(tempPCHP);
      // // tempNPC.SetHP(tempNPCHP);
      // newPC.Update(newPC.GetName(), newPC.GetPCType(), tempPCHP, newPC.GetAC(), newPC.GetDamage(), newPC.GetLVL(), newPC.GetEXP(), newPC.GetRoomId());
      // tempNPC.Update(tempNPC.GetName(), tempNPC.GetNPCType(), tempNPCHP, tempNPC.GetAC(), tempNPC.GetDamage(), tempNPC.GetLVL(), tempNPC.GetRoomId());
      //
      // string[] message = new string[] {"","","",""};
      // message[0] = "You attack the " + tempNPC.GetName() + "\n";
      // if (PCRoll >= PCThac0-tempNPC.GetAC() ) { message[1] = "You do " + PCDamage + " points of damage!!" + "\n"; } else { message[1] = "You miss it!"; }
      // message[2] = "The " + tempNPC.GetName() + " attacks you back.\n";
      // if (NPCRoll >= NPCThac0-newPC.GetAC() ) { message[3] = "It does " + NPCDamage + " points of damage to you!\n"; } else { message[3] = "It misses you!"; }

      //
      // THAC0 - (roll on a d20) = AC Hit.
      myGame["message"] = message;
      // return View("Fight", myGame);
      return View(newView, myGame);

    }


    [HttpGet("/game/combat/flee/{roomId}")]
    public ActionResult Flee(int roomId)
    {
      PC newPC = PC.Find(2);
      newPC.SetRoomId(roomId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);


      return View("Dead");
    }

          // [HttpGet("/game/examine/{roomId}")]
          // public ActionResult Examine(int ItemId)
          // {
          //   Console.WriteLine("Inside /game/examine/{roomId}");
          //   PC newPC = PC.Find(2);
          //   newPC.SetRoomId(ItemId);
          //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
          //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
          //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
          //   myGame.Add("pc", PC.Find(newPC.GetId()));
          //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
          //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
          //
          //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
          //
          //   myMap = Game.GetMap();
          //   myGame.Add("map", myMap);
          //
          //   Console.WriteLine("Room inside Look is: " + Room.Find(newPC.GetRoomId()).GetName());
          //   Console.WriteLine("in Look PC thinks its room # is: " + newPC.GetRoomId());
          //
          //   return View("Examine", myGame);
          // }

          [HttpGet("/drop/item/{itemId}")]
          public ActionResult Drop(int itemId)
          {
            Console.WriteLine("Inside /drop/item/{itemId} with Item " + Item.Find(itemId).GetName());
              // List<Item> tempItems = new List<Item>{};
              // tempItems = PC.Find(PCId).GetInventory();
              PC newPC = PC.Find(2);
              //
              List<Item> newItem = newPC.GetItems(); // passing stuff

              // Item.RemoveItemFromPC(itemId); // Taking Item from Inventory
//or
              newPC.DropItemFromPC(itemId);

              Item.Find(itemId).AddToContents(newPC.GetRoomId()); // Dropping Item into Room.

              // Item tempItem = Item.Find(itemId);
              // newPC.AddItemToPC(Item.Find(itemId));
              // tempItem.RemoveFromContents(itemId);

              // newPC.SetRoomId(pcId);
              Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
              Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
              //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
              myGame.Add("pc", PC.Find(newPC.GetId()));
              myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
              myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
              myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
              myMap = Game.GetMap();
              myGame.Add("map", myMap);
              myGame.Add("stuff", newItem);

              return View("GameIndex", myGame);
          }



          [HttpGet("/game/examine/{PCId}")]
          public ActionResult ExamineMe(int PCId)
          {
            Console.WriteLine("Inside /game/examine/{PCId}");
              List<Item> tempItems = new List<Item>{};
              tempItems = PC.Find(PCId).GetInventory();
              // For through the items tempItem.GetName();
              // offer each item with a link to the Examine command
              // if they click on the link, show a screen displaying the info from Examine
              return View("Examine", tempItems);
          }

          [HttpGet("/game/examine/item/{itemId}")]
          public ActionResult ExamineItem(int itemId)
          {
              Item tempItem = Item.Find(itemId);
              // For through the items tempItem.GetName();
              // offer each item with a link to the Examine command
              // if they click on the link, show a screen displaying the info from Examine
              return View("ExamineDetails", tempItem);
          }

  }

}
