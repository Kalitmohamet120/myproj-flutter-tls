import '../../widgets/avatar.dart';
import 'package:flutter/material.dart';

class PostWidget extends StatelessWidget {
  final String text;
  final String image;
  final int comment;
  final int like;
   final int share;
  const PostWidget({super.key, required this.text, required this.image, required this.comment, required this.like, required this.share});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: Color.fromARGB(255, 214, 219, 215),
      child: Column(
        children: [

          postHeader(),
          content(),
        ],
      ),
    );
  }

  postHeader() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        Avatar(),
        Expanded(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text('khalid hassan'),
              Row(
                children: [
                  Text('just now'),
                  Container(
                    height: 5,
                    width: 5,
                    decoration:
                        BoxDecoration(color: Colors.grey, shape: BoxShape.circle),
                  ),
                  Icon(Icons.public)
                ],
              ),
             
            ],
          ),
        ),
         Row(children: [Icon(Icons.more_horiz_rounded),
            Icon(Icons.close),],)
      ],
    );
  }

  content(){
    return Column(children: [
      Text(text ),
   Container(width:double.infinity,child: Image.asset('assets/two.jpg',fit: BoxFit.cover,width: 200,height: 200,)),
   
    Row(children: [Icon(Icons.thumb_up_alt_outlined),SizedBox(width: 200,),
     Icon(Icons.message_outlined),SizedBox(width: 200,),
      Icon(Icons.call_end_outlined),SizedBox(width: 4,),
    
    
    ],)],);
   
   }
}
