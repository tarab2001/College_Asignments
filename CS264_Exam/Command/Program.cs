/*using the command pattern and desing pattern I have implemented an app to add emojis to a canvas. Ther command pattern is used to implement the 
undo/redo functionality and the desing patter is used to create the emoji
Using Windows and VS Code 
*/
using System;
using System.Collections.Generic;
using System.IO;
namespace CS264_Exam{
    class Program{
        static void Main(string[] args){
            //Random r= new Random();
            String s = ""; //contain values to add to SVG file
            Console.WriteLine("Canvas created. Use commands to add,remove,style or move emojis to canvas!");//line to prompt user
            String s1 = Console.ReadLine();//read shape from user
            List<Emoji> emojis = new List<Emoji>();//list to add emojis too
            List<String> hide = new List<String>(); //list to handle hidden command
            List<Emoji> undoRedo = new List<Emoji>(); //list to handle undo/redo
            String SVGOpen = "<svg viewBox=\"0 0 200 200\" + xmlns=\"http://www.w3.org/2000/svg\">";//first line of SVG file
            s = s + SVGOpen;//add to empty string
            while(s1 != "quit"){
                if(s1.Split(' ')[0] == "show"){
                    String feature = s1.Split(' ')[1];
                    if(feature == "mouth"){
                        //get element for feature
                        String d = "M 22.29,28.7c0.3266-0.4271,1.792-2.245,4.424-2.685c2.135-0.3566,3.794,0.4017,4.352,0.688";
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        mouth m1 = new mouth(d,stroke,strokeW,fill);//mouth added
                        hide.Add("mouth");
                        emojis.Add(m1);
                        Console.WriteLine("Mouth (style 1) added to canvas");
                    }
                    else if(feature == "left-eye"){
                        //get element for feature
                        int cx = 28;
                        int cy = 38;
                        int r = 5; 
                        String stroke = "black";
                        String strokeW = "1";
                        String fill = "black";
                        leftEye le = new leftEye(cx,cy,r,stroke,strokeW,fill);//left eye added
                        emojis.Add(le);
                        hide.Add("left-eye");
                        Console.WriteLine("Left eye (style 1) added to canvas");
                    }
                    else if(feature == "right-eye"){
                        //get element for feature
                        int cx = 43;
                        int cy = 33;
                        int r = 5;
                        String stroke = "black";
                        String strokeW = "2";
                        String fill = "black";
                        rightEye re = new rightEye(cx,cy,r,stroke,strokeW,fill);//right eye added
                        emojis.Add(re);
                        hide.Add("right-eye");
                        Console.WriteLine("Right eye (style 1) added to canvas");
                    }
                    else if(feature == "left-brow"){
                        //get element for feature
                        int x =97;
                        int y= 66;
                        int w= 6;
                        int h = 32;
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        String t = "rotate(80)";
                        leftBrow lb = new leftBrow(x,y,w,h,stroke,strokeW,fill,t); //left brow added
                        emojis.Add(lb);//add update to list
                        hide.Add("left-brow");
                        Console.WriteLine("Left brow (style 1) added to canvas");
                    }
                    else if(feature == "right-brow"){
                        //get element for feature
                        int x =97;
                        int y= 66;
                        int w= 6;
                        int h = 32;
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        String t = "rotate(80)";
                        rightBrow rb = new rightBrow(x,y,w,h,stroke,strokeW,fill,t); //right brow added
                        emojis.Add(rb);//add update to list
                        hide.Add("right-brow");
                        Console.WriteLine("Right brow (style 1) added to canvas");
                    }
                    else{
                        Console.WriteLine("Feature not recognised");
                    }
                }
                else if(s1.Split(' ')[0] == "hide"){
                    String move = s1.Split(' ')[1];
                    int len = emojis.Count-1;
                    if(move == "mouth"){
                        for(int i = hide.Count-1; i > 0 ; i--){//go through array and hide feature
                            if(hide[i] == "mouth"){
                                emojis.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                                break;
                            }
                        }
                        Console.WriteLine( "Mouth hidden from canvas");
                    }
                    else if(move == "left-eye"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "left-eye"){
                                emojis.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                                break;
                            }
                        }
                        Console.WriteLine("Left eye hidden from cnavas");
                    }
                    else if(move == "right-eye"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "right-eye"){
                                emojis.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                                break;
                            }
                        }
                        Console.WriteLine("Right eye hidden from cnavas");                        
                    }
                    else if(move == "left-brow"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "left-brow"){
                                emojis.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                                break;
                            }
                        }
                        Console.WriteLine("Left brow hidden from cnavas");                        
                    }
                    else if(move == "right-brow"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "right-brow"){
                                emojis.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                                break;
                            }
                        }
                        Console.WriteLine("Right brow hidden from cnavas");
                    }
                }
                else if(s1.Split(' ')[0] == "style"){
                    String style = s1.Split(' ')[1];
                    String type = s1.Split(' ')[2];
                    if(style == "mouth"){
                        if(type == "1"){
                            String d = "M 85 130 C 85 120, 115 115, 115 120";
                            String fill = "black"; 
                            String strokeW = "2";
                            String stroke = "black";
                            mouth m1 = new mouth(d,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "mouth"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(m1);
                        }
                        else if(type == "2"){
                            String d = "M 100, 160, Q 128, 190 156, 160";
                            String fill = "red"; 
                            String strokeW = "2";
                            String stroke = "black";
                            mouth m1 = new mouth(d,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "mouth"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(m1);
                        }
                        else if(type =="3"){
                            String d = "M 100 100 L 300  10";
                            String fill = "pink"; 
                            String strokeW = "2";
                            String stroke = "black";
                            mouth m1 = new mouth(d,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "mouth"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(m1);
                        }
                    }
                    else if(style == "left-eye"){
                        if(type == "1"){
                            int cx =80;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "left-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//style updated

                        }
                        else if(type == "2"){
                            int cx =80;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "left-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//style updated


                        }
                        else if(type =="3"){
                            int cx =80;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "left-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//style updated


                        }
                    }
                    else if(style == "right-eye"){
                       if(type == "1"){
                            int cx =120;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            rightEye re = new rightEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(re);

                        }
                        else if(type == "2"){
                            int cx =140;
                            int cy =76;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "blue";
                            rightEye re = new rightEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(re);


                        }
                        else if(type =="3"){
                            int cx =179;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "brown";
                            rightEye re = new rightEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(re);//updated style

                        }
                        
                    }
                    else if(style == "left-brow"){
                        if(type == "1"){
                            int x =80;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rottate(80)";
                            leftBrow lb = new leftBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "left-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(lb);//add update to list
                        }
                        else if(type == "2"){
                            int x =80;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(120)";
                            leftBrow lb = new leftBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "left-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(lb);//add update to list
                        }
                        else if(type =="3"){
                            int x =80;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(100)";
                            leftBrow lb = new leftBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "left-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(lb);//add update to list
                        }
                        
                    }
                    else if(style == "right-brow"){
                        if(type == "1"){
                            int x =80;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(80)";
                            rightBrow rb = new rightBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(rb);//add update to list
                        }
                        else if(type == "2"){
                            int x =97;
                            int y =66;
                            int w = 6;
                            int h = 35;
                            String stroke = "white";
                            String strokeW= "2";
                            String fill = "brown";
                            String t = "rotate(120)";
                            rightBrow rb = new rightBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(rb);//add update to list
                        }
                        else if(type =="3"){
                            int x =80;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(100)";
                            rightBrow rb = new rightBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp trough list and change style
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(rb);//add update to list
                        }
                        
                    }
                }
                else if(s1.Split(' ')[0] == "move"){
                    String move = s1.Split(' ')[1];
                    String pos = s1.Split(' ')[2];
                    String val = s1.Split(' ')[3];
                    if(move == "left-eye"){
                        if(pos == "up"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120;
                            int cy = 95 + y;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feaure
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//update added to list

                            
                        }
                        else if(pos == " down"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120;
                            int cy = 95 - y;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                           for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//update added to list

                            

                        }
                        else if(pos == "left"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120 - y;
                            int cy = 95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                           for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//update added to list

                            

                        }
                        else if(pos == "right"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120 + y;
                            int cy = 95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                           for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//update added to list

                            

                        }
                    }
                    else if(move == "right-eye"){
                        if(pos == "up"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120;
                            int cy =95 + y;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){//lopp through list and remove feature
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//update added to list

                            
                        }
                        else if(pos == " down"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120;
                            int cy =95 - y;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                           for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);//update added to list


                        }
                        else if(pos == "left"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120 - y;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le); //update added to list


                        }
                        else if(pos == "right"){
                            String x = s1.Split(' ')[4];
                            int y = Int32.Parse(x);
                            int cx =120 + y;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-eye"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(le);


                        }
                    }
                    else if(move == "left-brow"){
                        if(pos == "up"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80;
                            int y =95 + y1;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rottate(80)";
                            leftBrow lb = new leftBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "left-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(lb);//add update to list
                            
                        }
                        else if(pos == " down"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80;
                            int y =95 - y1;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rottate(80)";
                            leftBrow lb = new leftBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "left-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(lb);//add update to list

                        }
                        else if(pos == "left"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80 - y1;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rottate(80)";
                            leftBrow lb = new leftBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "left-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(lb);//add update to list

                        }
                        else if(pos == "right"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80 - y1;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rottate(80)";
                            leftBrow lb = new leftBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "left-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(lb);//add update to list

                        }
                    }
                    else if(move == "right-brow"){
                        if(pos == "up"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80;
                            int y =95 - y1;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(80)";
                            rightBrow rb = new rightBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(rb);//add update to list
                            
                        }
                        else if(pos == " down"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80;
                            int y =95 + y1;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(80)";
                            rightBrow rb = new rightBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(rb);//add update to list

                        }
                        else if(pos == "left"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80 - y1;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(80)";
                            rightBrow rb = new rightBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(rb);//add update to list//add update to list

                        }
                        else if(pos == "right"){
                            String x1 = s1.Split(' ')[4];
                            int y1= Int32.Parse(x1);
                            int x =80 + y1;
                            int y =95;
                            int w = 13;
                            int h = 35;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            String t = "rotate(80)";
                            rightBrow rb = new rightBrow(x,y,w,h,stroke,fill,strokeW,t);
                            for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                }
                            }
                            emojis.Add(rb);//add update to list//add update to list

                        }
                    }
                }
                else if(s1.Split(' ')[0] == "reset"){
                    String move = s1.Split(' ')[1];
                    if(move == "mouth"){
                        String d = "M 85 130 C 85 120, 115 155, 115 120";
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        mouth m1 = new mouth(d,stroke,strokeW,fill);
                         for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                    hide.Remove(hide[i]);
                                }
                            }
                        hide.Add("mouth");
                        emojis.Add(m1);
                        Console.WriteLine("Mouth reverted to Style 1");
                        
                    }
                    else if(move == "left-eye"){
                        int cx = 80;
                        int cy = 95;
                        int r = 15; 
                        String stroke = "black";
                        String strokeW = "1";
                        String fill = "black";
                        leftEye le = new leftEye(cx,cy,r,stroke,strokeW,fill);
                         for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                    hide.Remove(hide[i]);
                                }
                            }
                        emojis.Add(le);
                        hide.Add("left-eye");
                        Console.WriteLine("Left eye reverted to Style 1");

                    }
                    else if(move == "right-eye"){
                        int cx = 120;
                        int cy = 95;
                        int r = 13;
                        String stroke = "black";
                        String strokeW = "2";
                        String fill = "black";
                        rightEye re = new rightEye(cx,cy,r,stroke,strokeW,fill);
                         for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                    hide.Remove(hide[i]);
                                }
                            }
                        emojis.Add(re);
                        hide.Add("right-eye");
                        Console.WriteLine("Right eye reverted to Style 1");
                    }
                    else if(move == "left-brow"){
                        int x =97;
                        int y= 66;
                        int w= 6;
                        int h = 32;
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        String t = "rotate(80)";
                        leftBrow lb = new leftBrow(x,y,w,h,stroke,strokeW,fill,t);
                         for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                    hide.Remove(hide[i]);
                                }
                            }
                        emojis.Add(lb);//add update to list
                        hide.Add("left-brow");
                        Console.WriteLine("Left brow reverted to Style 1");                        
                    }
                    else if(move == "right-brow"){
                        int x =97;
                        int y= 66;
                        int w= 6;
                        int h = 32;
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        String t = "rotate(80)";
                        rightBrow rb = new rightBrow(x,y,w,h,stroke,strokeW,fill,t);
                         for(int i = emojis.Count-1; i > 0; i++){//lopp through list and remove feature
                                if(hide[i] == "right-brow"){
                                    emojis.Remove(emojis[i]);
                                    hide.Remove(hide[i]);
                                }
                            }
                        emojis.Add(rb);//add update to list
                        hide.Add("right-brow");
                        Console.WriteLine("Right brow reverted to Style 1");
                        
                    }
                }
                else if(s1 == "undo"){
                   int len = emojis.Count-1; //length of shape list
                   undoRedo.Add(emojis[len]);//add last shapes to new list
                   emojis.Remove(emojis[len]); //remove shapes from main list
                   Console.WriteLine("Last commant undone");
                }
                else if(s1 == "redo"){
                    int len = undoRedo.Count-1; //length of undo list
                    emojis.Add(undoRedo[len]); //add last element of undo list to shapes list
                    undoRedo.Remove(undoRedo[len]);//remove shape from undo list
                    Console.WriteLine("Last command redone");
                }
                else if(s1 == "save"){
                    s = create(emojis);
                    File.WriteAllText(@"C:\Users\tarab\CS264_Exam\Command\Emojis.SVG", s); //create SVG file
                    Console.WriteLine("File saved!");
                }
                else if(s1 == "draw"){
                    s = create(emojis);
                    Console.WriteLine(s);
                }
                else if(s1 == "help"){
                    Console.WriteLine("Commands: ");
                    Console.WriteLine("         show <feature>                        Add <feature> to canvas");
                    Console.WriteLine("         hide <feature>                        Removes <feature> from canvas");
                    Console.WriteLine("         move <feature> <up|down|left|right>   Moves <feature> to position");
                    Console.WriteLine("         reset <feature>                       Resets <feature> to default");
                    Console.WriteLine("         style <feature> <1|2|3>               Sets <feature> style to <1|2|3>");
                    Console.WriteLine("         save                                  Save canvas");
                    Console.WriteLine("         draw                                  Display canvas");
                    Console.WriteLine("         undo                                  Undo last operation");
                    Console.WriteLine("         redo                                  Redo last operation");
                    Console.WriteLine("         help                                  Help- diplays this message");
                    Console.WriteLine("         quit                                  Quit application");
                }
                else{
                    Console.WriteLine("Input not recognsied!!");
                }
                s1 = Console.ReadLine(); //read next line from user
            }
            Console.WriteLine("Goodbye!");

        }
         public static String create(List<Emoji> emojis){
            String add = "";//string to add emoji too
            String SVGOpen = "<svg width = \"200\" height = \"200\" viewBox=\"0 0 72 72\" xmlns=\"http://www.w3.org/2000/svg\">";
            String face = "<circle cx = \"36\" cy = \"36\" r = \"23\" stoke = \"black\" stroke-width = \"2\" fill = \"yellow\" />";
            add = add + SVGOpen + Environment.NewLine + face;
            foreach (var emoji in emojis)
                    {
                        add = add + Environment.NewLine.PadLeft(15) +  emoji.Create(); //add emoji feature to string
                    }
                    string SVGClose = "</svg>"; //last line of SVG file
                    add = add + Environment.NewLine + SVGClose; // add closing line to string
            //File.WriteAllText(@"C:\Users\tarab\CS264-Assignment-3\Shapes.SVG", s); //create SVG file
            return add;
        }
    }

    //using decorator desing pattern
    //abstract class
    public abstract class Emoji{
        
        public Emoji(){           
        }
        public virtual string Create(){
            String s = "";
            return s;
        }
        
    }
    //concrete classes for features of emoji
    public class leftEye : Emoji{
        int cx = 80, cy = 95, r = 13;
        string fill, stroke, strokeW;
        public leftEye(){
            this.cx = 29;
            this.cy = 93;
            this.r = 5;
            this.fill = "black"; 
            this.strokeW = "2";
            this.stroke = "black";
        }
        public leftEye(int cx, int cy, int r, string fill,string strokeW,string stroke){
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            this.fill = fill; 
            this.strokeW = strokeW;
            this.stroke = stroke;
        }
        public override string Create(){
            Circle c = new Circle(this.cx,this.cy,this.r,this.fill,this.stroke,this.strokeW);
            return c.Create();
        }
    }
    public class rightEye : Emoji{
        int cx = 120, cy = 95, r = 13;
        string fill, stroke, strokeW;
        public rightEye(){
            this.cx = 43;
            this.cy = 33;
            this.r = 5;
            this.fill = "black"; 
            this.strokeW = "2";
            this.stroke = "black";
        }
        public rightEye(int cx, int cy, int r,string fill,string strokeW,string stroke){
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            this.fill = fill; 
            this.strokeW = strokeW;
            this.stroke = stroke;
        }      
        public override string Create(){
            Circle c = new Circle(this.cx,this.cy,this.r,this.fill,this.stroke,this.strokeW);
            return c.Create();
        }
    }
    public class leftBrow : Emoji{
        string  fill, stroke, strokeW,transform;
        int x, y, h, w;
        public leftBrow(){
            this.x = 97;
            this.y = 66;
            this.w = 6;
            this.h = 32;
            this.fill = "black"; 
            this.strokeW = "2";
            this.stroke = "black";
            this.transform = "rotate(80)";
        }
        public leftBrow(int x, int y, int w, int h, string fill,string strokeW,string stroke,string transform){
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.fill = fill; 
            this.strokeW = strokeW;
            this.stroke = stroke;
            this.transform = transform;
        }
        public override string Create(){
            Rec r = new Rec(this.x,this.y,this.w,this.h,this.stroke,strokeW,this.fill,this.transform);
            return r.Create();
        }
    }
    public class rightBrow : Emoji{
        string fill, stroke, strokeW,transform;
        int x,y,w,h;
        public rightBrow(){
            this.x = 97;
            this.y = 66;
            this.w = 6;
            this.h = 32;
            this.fill = "black"; 
            this.strokeW = "2";
            this.stroke = "black";
            this.transform = "rotate(80)";
        }
        public rightBrow(int x, int y, int w, int h, string fill,string strokeW,string stroke,string transform){
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.fill = fill; 
            this.strokeW = strokeW;
            this.stroke = stroke;
            this.transform = transform;
        }        
        public override string Create(){
            Rec r = new Rec(this.x,this.y,this.w,this.h,this.stroke,this.strokeW,this.fill,this.transform);
            return r.Create();
        }
    }
    public class mouth : Emoji{
        string d,strokeW,stroke,fill;
        public mouth(){
            this.d = "M22.29,28.7c0.3266-0.4271,1.792-2.245,4.424-2.685c2.135-0.3566,3.794,0.4017,4.352,0.688";
            this.fill = "black"; 
            this.strokeW = "2";
            this.stroke = "black";
        }
        public mouth(string d, string strokeW, string stroke, string fill){
            this.d = d;
            this.fill = fill; 
            this.strokeW = strokeW;
            this.stroke = stroke;
        }
       
        public override string Create(){
            return "<circle cx=\"" + 80 + "\" cy=\"" + 95 + "\" r=\"" + 13 + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeW + "\" fill=\"" +this.fill + "\"/>";
        }
    }

    public class Circle{
        int cx, cy,r;
        String fill,stroke,strokeW;
        public Circle(){
            this.r = 13;
            this.cx = 85;
            this.cy = 95;
        }
        public Circle(int cx, int cy, int r, string fill, string stroke, string strokeW){
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            this.fill = fill;
            this.stroke = stroke;
            this.strokeW = strokeW;
        }
        public String Create(){
            return "<circle cx=\"" + this.cx + "\" cy=\"" + this.cy + "\" r=\"" + this.r + "\" stroke =\"" + this.stroke + "\" stroke-width=\"" + this.strokeW + "\" fill=\"" + this.fill +"\"/>";
        }
    }

    public class Rec{
        public int x; //x pos
        public int y; //y pos
        public int w; //width
        public int h;//height
        public string fill = "";//colour of shape
        public string stroke = ""; //line colour
        public string stroke_w = ""; //stroke width
        public string transform;
        public Rec(){//set x,y,h,w
            x = 10;
            y = 10;
            w = 10;
            h = 10;
            fill = "red";
            stroke = "black";
            stroke_w = "2";
            transform = "rotate(80)";
        }
        public Rec(int x,int y,int w,int h,string s,string s1,string s2,string t){//get x,y,h,w
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.fill = s;
            this.stroke = s1;
            this.stroke_w = s2;
            this.transform = t;
        }

        public String Create(){//create Rectangle in SVG file
            return "<rect x=\""+ this.x + "\" y=\"" + this.y + "\" width=\"" + this.w + "\" height=\"" + this.h +"\"fill=\"" + this.fill + "\" stroke=\"" +this.stroke +"\"  stoke-width=\"" +this.stroke_w +"\" transform=\"" + this.transform + "\"/>";
        }
    }
    public class Path{
        public string s,fill,stroke,strokeW;
        public Path(){
        }
        public Path(string s,string fill,string stroke, string strokeW){
            this.s = s;
            this.stroke = stroke;
            this.strokeW = strokeW;
            this.fill = fill;
        }
        public String Create(){
            String s1 = "<path d=\"" +this.s + "\"stroke= \"" +this.stroke+ "\" stroke-width=\"" + this.strokeW + "\" fill=\"" +this.fill + "\"/>";
            return s1;
        }         
    }

   



}