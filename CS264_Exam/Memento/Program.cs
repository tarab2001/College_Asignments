/*using the memento pattern and desing pattern I have implemented an app to add emojis to a canvas. Ther memento pattern is used to implement the 
undo/redo functionality and the desing patter is used to create the emoji
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
            Canvas canvas = new Canvas(); //cnavas created
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();
            Console.WriteLine("Canvas created. Use commands to add shapes to canvas!");//line to prompt user
            String s1 = Console.ReadLine();//read feature from user
            List<String> hide = new List<String>(); //list to help hide features
            while(s1 != "quit"){
                if(s1.Split(' ')[0] == "show"){
                    String feature = s1.Split(' ')[1];
                    if(feature == "mouth"){
                        //get element for feature
                        int x1 = 85;
                        int x2 = 115;
                        int y1 = 120;
                        int y2= 120;
                        String stroke = "black";
                        String strokeW = "3";
                        mouth m1 = new mouth(x1,y1,x2,y2,stroke,strokeW); //mouth added
                        canvas.AddMouth(m1); //added to canvas
                        hide.Add("mouth");
                        Console.WriteLine("Mouth (style 1) added to canvas");
                    }
                    else if(feature == "left-eye"){
                        //get element for feature
                        int cx = 80;
                        int cy = 95;
                        int r = 13;
                        String stroke = "black";
                        String strokeW = "1";
                        String fill = "black";
                        leftEye le = new leftEye(cx,cy,r,stroke,strokeW,fill);
                        canvas.AddLeftEye(le);
                        hide.Add("left-eye");
                        Console.WriteLine("Left eye (style 1) added to canvas");
                    }
                    else if(feature == "right-eye"){
                        //get element for feature
                        int cx = 120;
                        int cy = 95;
                        int r = 13;
                        String stroke = "black";
                        String strokeW = "2";
                        String fill = "black";
                        rightEye re = new rightEye(cx,cy,r,stroke,strokeW,fill);
                        canvas.AddRightEye(re);
                        hide.Add("right-eye");
                        Console.WriteLine("Right eye (style 1) added to canvas");
                    }
                    else if(feature == "left-brow"){
                        //get element for feature
                        String d = "M 85 130 C 85 120, 115 155, 115 120";
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        leftBrow lb = new leftBrow(d,stroke,strokeW,fill);
                        canvas.AddLeftBrow(lb);
                        hide.Add("left-eye");
                        Console.WriteLine("Left brow (style 1) added to canvas");
                    }
                    else if(feature == "right-brow"){
                        //get element for feature
                        String d = "M 85 130 C 85 120, 115 155, 115 120";
                        String stroke = "black";
                        String strokeW = "3";
                        String fill = "black";
                        rightBrow rb = new rightBrow(d,stroke,strokeW,fill);
                        canvas.AddRightBrow(rb);
                        hide.Add("right-eye");
                        Console.WriteLine("Right brow (style 1) added to canvas");
                    }
                    else{
                        Console.WriteLine("Feature not recognised");
                    }
                }
                else if(s1.Split(' ')[0] == "hide"){
                    String move = s1.Split(' ')[1];
                    int len = hide.Count-1;
                    if(move == "mouth"){
                        for(int i = hide.Count-1; i > 0 ; i--){ 
                            if(hide[i] == "mouth"){
                                canvas.Remove(hide[i]); //hide feature from file
                                break;
                            }
                        }
                        Console.WriteLine( "Mouth hidden from canvas");
                    }
                    else if(move == "left-eye"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "left-eye"){
                                canvas.Remove(hide[i]);//hide feature from file
                                break;
                            }
                        }
                        Console.WriteLine("Left eye hidden from cnavas");
                    }
                    else if(move == "right-eye"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "right-eye"){
                                canvas.Remove(hide[i]);//hide feature from file
                                break;
                            }
                        }
                        Console.WriteLine("Right eye hidden from cnavas");                        
                    }
                    else if(move == "left-brow"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "left-brow"){
                                canvas.Remove(hide[i]);//hide feature from file
                                break;
                            }
                        }
                        Console.WriteLine("Left brow hidden from cnavas");                        
                    }
                    else if(move == "right-brow"){
                        for(int i = hide.Count-1; i > 0 ; i--){
                            if(hide[i] == "right-brow"){
                                canvas.Remove(hide[i]);//hide feature from file
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
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "mouth"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(m1);//update feaute to style selected
                        }
                        else if(type == "2"){
                            String d = "M 100, 160, Q 128, 190 156, 160";
                            String fill = "red"; 
                            String strokeW = "2";
                            String stroke = "black";
                            mouth m1 = new mouth(d,stroke,fill,strokeW);
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "mouth"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                           canvas.Add(m1);//update feaute to style selected
                        }
                        else if(type =="3"){
                            String d = "M 100 100 L 300  10";
                            String fill = "pink"; 
                            String strokeW = "2";
                            String stroke = "black";
                            mouth m1 = new mouth(d,stroke,fill,strokeW);
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "mouth"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                           canvas.Add(m1);//update feaute to style selected
                        }
                    }
                    else if(style == "left-eye"){
                            int cx =80;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "left-eye"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(le);//update feaute to style selected
                        }
                        else if(type == "2"){
                            int cx =80;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "left-eye"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(le);//update feaute to style selected
                        }
                        else if(type =="3"){
                            int cx =80;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "black";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i =canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "left-eye"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(le);//update feaute to style selected

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
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "right-eye"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(le);
                        }
                        else if(type == "2"){
                            int cx =140;
                            int cy =76;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "blue";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "right-eye"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(le);//update feaute to style selected

                        }
                        else if(type =="3"){
                            int cx =179;
                            int cy =95;
                            int r = 13;
                            String stroke = "black";
                            String strokeW= "2";
                            String fill = "brown";
                            leftEye le = new leftEye(cx,cy,r,stroke,fill,strokeW);
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "right-eye"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(le);//update feaute to style selected
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
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "left-brow"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(lb);//update feaute to style selected
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
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "left-brow"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(lb);//update feaute to style selected
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
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "left-brow"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(lb);//update feaute to style selected
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
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "right-brow"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(rb);//update feaute to style selected
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
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "right-brow"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.Add(rb);//update feaute to style selected
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
                            for(int i = canvas.emojis.Count-1; i > 0; i++){ //go trough list remove feature
                                if(hide[i] == "right-brow"){
                                   canvas.Remove(canvas.emojis[i]);
                                }
                            }
                            canvas.emojis.Add(rb);//update feaute to style selected
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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){
                                    canavas.Remove(emojis[i]);
                                }
                            }
                            canavas.Add(le);//update feaute to style selected
                            
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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(le);//update feaute to style selected
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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(le);//update feaute to style selected                          
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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(le);//update feaute to style selected
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
                                if(hide[i] == "right-eye"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(le);//update feaute to style selected
                            
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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(le);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(le);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-eye"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(le);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "left-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(lb);//update feaute to style selected
                            
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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "left-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(lb);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "left-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(lb);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "left-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(lb);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(rb);//update feaute to style selected
                            
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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(rb);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(rb);//update feaute to style selected

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
                            for(int i = emojis.Count-1; i > 0; i++){
                                if(hide[i] == "right-brow"){
                                    canvas.Remove(emojis[i]);
                                }
                            }
                           canvas.Add(rb);//update feaute to style selected

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
                         for(int i = emojis.Count-1; i > 0; i++){
                            if(hide[i] == "right-brow"){
                                canvas.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                            }
                        }
                        hide.Add("mouth");
                        canvas.Add(m1);//reset feature to default
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
                        for(int i = emojis.Count-1; i > 0; i++){
                            if(hide[i] == "right-brow"){
                                canvas.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                            }
                        }
                        canvas.Add(le);//reset feature to default
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
                        for(int i = emojis.Count-1; i > 0; i++){
                            if(hide[i] == "right-brow"){
                                canvas.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                            }
                        }
                        canvas.Add(re);//reset feature to default
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
                        for(int i = emojis.Count-1; i > 0; i++){
                            if(hide[i] == "right-brow"){
                                canvas.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                            }
                        }
                       canvas.Add(lb);//reset feature to default
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
                        for(int i = emojis.Count-1; i > 0; i++){
                            if(hide[i] == "right-brow"){
                                canvas.Remove(emojis[i]);
                                hide.Remove(hide[i]);
                            }
                        }
                        canavas.Add(rb);//reset feature to default
                        hide.Add("right-brow");
                        Console.WriteLine("Right brow reverted to Style 1");
                        
                    }
                }
                else if(s1 == "undo"){
                   canvas.Undo(); //undo command
                    Console.WriteLine("Last operation undone!");
                }
                else if(s1 == "redo"){
                    canvas.Redo();//redo command
                    Console.WriteLine("Last operation redone!");
                }
                else if(s1 == "save"){
                    canvas.SaveCanvas();//dave canavas to file
                    Console.WriteLine("Canavs saved!");
                }
                else if(s1 == "draw"){
                   canvas.DisplayCanvas();//display cnavas
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
    }

  public class Canvas
    {
        public List<Emoji> emojis = new List<Emoji>(); // using list to store shapes
        Caretaker caretaker = new Caretaker();

        public Canvas() { }

        public Canvas(Canvas other) { 
            foreach (var emoji in other.emojis) {
               canvas.Add(emoji);
            }//add emoji to canvas
        }
        public void AddMouth(Emoji m)
        {
            Memento curr = new Memento(m.Create());
            caretaker.add(curr);
        }
        public void AddLeftEye(Emoji le)
        {
            Memento curr = new Memento(le.Create());
            caretaker.add(curr);
        }
        public void AddRightEye(Emoji re)
        {
            Memento curr = new Memento(re.Create());
            caretaker.add(curr);
        }
        public void AddLeftBrow(Emoji lb)
        {
            Memento curr = new Memento(lb.Create());
            caretaker.add(curr);
        }
        public void AddRightBrow(Emoji rb)
        {
            Memento curr = new Memento(rb.Create());
            caretaker.add(curr);
        }


        public void DisplayCanvas()
        {
            // create the opening and closing tags for the svg canvas
            String SVGOpen = "<svg width = \"200\" height = \"200\" viewBox=\"0 0 200 200\" xmlns=\"http://www.w3.org/2000/svg\">";
            String face = "<circle cx = \"100\" cy = \"100\" r = \"80\" stoke = \"black\" stroke-width = \"2\" fill = \"yellow\" />";
            String SVGClose = @"</svg>";

            // draw the canvas (write to the display)
            Console.WriteLine(SVGOpen);
            Console.WriteLine(face);
            // iterate over all shapes in the list
            foreach (var emoji in caretaker.mementoList) Console.WriteLine("".PadLeft(3, ' ') + emoji.getState());
            Console.WriteLine(SVGClose);
        }

        public void ClearCanvas(){
            caretaker.mementoList.Clear();
        }
        public void SaveCanvas(){
            String SVGOpen = "<svg width = \"200\" height = \"200\" viewBox=\"0 0 200 200\" xmlns=\"http://www.w3.org/2000/svg\">";
            String face = "<circle cx = \"100\" cy = \"100\" r = \"80\" stoke = \"black\" stroke-width = \"2\" fill = \"yellow\" />";
            String s = SVGOpen + Environment.NewLine + face;
            foreach (var emoji in caretaker.mementoList)
                    {
                        s = s + Environment.NewLine.PadLeft(15) +  emoji.getState(); //add shape to string
                    }
                    string SVGClose = "</svg>"; //last line of SVG file
                    s = s + Environment.NewLine + SVGClose; // add closing line to string
            File.WriteAllText(@"C:\Users\tarab\CS264_Exam\Memento\Emoji.SVG", s); //create SVG file
        }
        public void Undo(){
            caretaker.undo();
        }
        public void Redo(){
            caretaker.redo();
        }
        public void Remove(){
            caretaker.Remove();
        }
    }
    //using decorator desing pattern
    //abstract class
    public abstract class Emoji{
        public Emoji(){
        }
        public virtual string Create(){
            String s = " ";
            return s;
        }
        public virtual string Style1(){
            String style = "";
            return style;
        }
    }
    //concrete classes for features of emoji
    public class leftEye : Emoji{
        int cx = 80, cy = 95, r = 13;
        string fill = "black", stroke = "black", strokeWidth = "2";
        public leftEye(){
            cx = 80;
            cy = 95;
            r = 13;
            fill = "black";
            stroke = "black";
            strokeWidth = "2";
        }
        public leftEye(int cx, int cy, int r, string stroke, string strokeWidth, string fill){
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
            this.fill = fill;
        }
        public override string Create(){
            return "<circle cx=\"" + 80 + "\" cy=\"" + 95 + "\" r=\"" + 13 + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" fill=\"" +this.fill + "\"/>";
        }
        public override string Style1(){
            this.cx = 50;
            this.cy = 100;
            this.r = 13;
            this.fill = "blue";
            this.stroke = "black";
            this.strokeWidth = "2";
            return  "<circle cx=\"" + this.cx + "\" cy=\"" + this.cy + "\" r=\"" + this.r + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" fill=\"" +this.fill + "\"/>";
        }
    }
    public class rightEye : Emoji{
        int cx = 120, cy = 95, r = 13;
        string fill = "black", stroke = "black", strokeWidth = "2";
        public rightEye(){
            cx = 120;
            cy = 95;
            r = 13;
            fill = "black";
            stroke = "black";
            strokeWidth = "2";
        }
        public rightEye(int cx, int cy, int r, string stroke, string strokeWidth, string fill){
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
            this.fill = fill;
        }
        public override string Create(){
            return "<circle cx=\"" + this.cx + "\" cy=\"" + this.cy + "\" r=\"" + this.r + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" fill=\"" + this.fill + "\"/>";
        }
    }
    public class leftBrow : Emoji{
        string d = "", fill = "black", stroke = "black", strokeWidth = "2";
        public leftBrow(){
            d = "M 85 130 C 85 120, 115 155, 115 120";
            fill = "transparent";
            stroke = "black";
            strokeWidth = "3";
        }
        public leftBrow(string d, string stroke, string strokeWidth, string fill){
            this.d = d;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
            this.fill = fill;
        }
        public override string Create(){
            return "<path d=\"" + this.d + "\" style = stroke=\"" + this.stroke +"\"; stroke-width=\"" + this.strokeWidth + "\" +fill=\"" + this.fill + "\"/>";
        }
    }
    public class rightBrow : Emoji{
        string d = "", fill = "black", stroke = "black", strokeWidth = "2";
        public rightBrow(){
            d = "M 85 130 C 85 120, 115 155, 115 120";
            fill = "transparent";
            stroke = "black";
            strokeWidth = "3";
        }
        public rightBrow(string d, string stroke, string strokeWidth, string fill){
            this.d = d;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
            this.fill = fill;
        }
        public override string Create(){
            return "<path d=\"" + this.d + "\" style = stroke=\"" + this.stroke +"\"; stroke-width=\"" + this.strokeWidth + "\" +fill=\"" + this.fill + "\"/>";
        }
    }
    public class mouth : Emoji{
        int x1,x2,y1,y2;
        string stroke = "black", strokeWidth = "2";
        public mouth(){
            x1 = 85;
            y1= 120;
            x2 = 115;
            y2 = 120;
            stroke = "black";
            strokeWidth = "3";
        }
        public mouth(int x1, int y1, int x2, int y2, string stroke, string strokeWidth){
            this.x1 = x1;
            this.y1= y1;
            this.x2 = x2;
            this.y2 = y2;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
        }
        public override string Create(){
            return "<line x1=\"" + this.x1 + "\" y1=\"" + this.y1 + "\" x2=\"" + x2 + "\" y2 =\"" + this.y2 + "\"style =\"stroke: this.stroke;stroke-width:this.strokeWidth\"/>";
        }
    }

    //Momento Class
    public interface IMemento
    {
        public string getState();
        public void setState(string state);
    }

    public class Memento : IMemento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string getState()
        {
            return state;
        }

        public void setState(string state)
        {
            this.state = state;
        }
    }

    // Originator Class
    public interface IOriginator {
        public void setState(string state);
        public string getState();
        public Memento createMemento();
        public void setMemento(Memento Memento);
    }

    public class Originator : IOriginator
    {
        private string state;

        public void setState(string state)
        {
            this.state = state;
        }

        public string getState()
        {
            return state;
        }

        public Memento createMemento()
        {   
            return new Memento(new string(state));
        }

        public void setMemento(Memento Memento)
        {  
            // restore 
            state = Memento.getState();
        }
    }

    // Caretaker class
        public interface ICaretaker {
        public void add(Memento state);
        public Memento get(int index);
    }

    public class Caretaker : ICaretaker
    {
        public List<Memento> mementoList = new List<Memento>();
        private List<Memento> RedoList = new List<Memento>();
        public void add(Memento state)
        {
            //Console.WriteLine(mementoList.Count);
            this.mementoList.Add(state);
            //Console.WriteLine(mementoList.Count);
        }
        public void undo()
        {
            //Console.WriteLine(mementoList.Count);
            this.RedoList.Add(this.mementoList[this.mementoList.Count-1]);
            this.mementoList.RemoveAt(this.mementoList.Count-1);
        }
        public void redo()
        {
            mementoList.Add(RedoList[RedoList.Count-1]);
            RedoList.RemoveAt(RedoList.Count-1);
        }
        public void Remove(){
            mementoList.RemoveAt(this.mementoList[this,mementoList.Count-1]);
        }

        public Memento get(int index)
        {
            return mementoList[index];
        }
    }
}