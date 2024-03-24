import 'package:flutter/material.dart';

class Avatar extends StatelessWidget {
  const Avatar({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 4),
      child: CircleAvatar(
        backgroundColor: Colors.red,
        radius: 20,
      ),
    );
  }
}
