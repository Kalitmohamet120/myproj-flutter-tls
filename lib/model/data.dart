import 'dart:math';

import 'package:faker/faker.dart' as faker;


class UserPost {
  final String text;
  final DateTime postedDate;
  final String images;
  late int likes;
  late int comment;
  final int share;
  final Privacy privacy;

  UserPost(
      {this.text = '',
      required this.postedDate,
      this.images = '',
      this.comment = 0,
      this.likes = 0,
      this.share = 0,
      required this.privacy});

  @override
  String toString() {
    return 'Post : $text, images, likes: $likes, comment: $comment}\n\n';
  }
}

enum Privacy {
  public,
  onlyMe,
}class Model{  static List<UserPost> posts() {
    return List.generate(
        10,
        (index) => UserPost(
            text: faker.faker.lorem.sentence(),
            postedDate: DateTime.now(),
            likes: Random().nextInt(100),
            share: Random().nextInt(100),
            comment: Random().nextInt(100),
            privacy: Privacy.public,
            images:'https://unsplash.com/photos/a-palm-tree-sitting-on-top-of-a-sandy-beach-Kcna6XWDY7w')
           );
  }









  
}