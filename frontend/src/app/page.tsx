'use client';
import { useEffect, useState } from 'react';
import axios from 'axios';

import heroPattern from '../assets/hero-pattern.jpg';

const Home = () => {
  const [blogPosts, setBlogPosts] = useState([
    {
      id: 1,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
      user: {
        username: 'Ercan1 Akalar',
      },
      comment: [
        { id: 2, username: 'Ercan2 Akalar' },
        { id: 3, username: 'Ercan2 Akalar' },
      ],
    },
    {
      id: 2,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
      user: {
        username: 'Ercan2 Akalar',
      },
      comment: [
        { id: 2, username: 'Ercan2 Akalar' },
        { id: 3, username: 'Ercan2 Akalar' },
      ],
    },
    {
      id: 3,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
      user: {
        username: 'Ercan3 Akalar',
      },
      comment: [
        { id: 2, username: 'Ercan2 Akalar' },
        { id: 3, username: 'Ercan2 Akalar' },
      ],
    },
    {
      id: 4,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
      user: {
        username: 'Ercan4 Akalar',
      },
      comment: [
        { id: 2, username: 'Ercan2 Akalar' },
        { id: 3, username: 'Ercan2 Akalar' },
      ],
    },
    {
      id: 5,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
      user: {
        username: 'Ercan5 Akalar',
      },
      comment: [
        { id: 2, username: 'Ercan2 Akalar' },
        { id: 3, username: 'Ercan2 Akalar' },
      ],
    },
    {
      id: 6,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
      user: {
        username: 'Ercan6 Akalar',
      },
      comment: [
        { id: 2, username: 'Ercan2 Akalar' },
        { id: 3, username: 'Ercan2 Akalar' },
      ],
    },
  ]);

  // useEffect(() => {
  //   axios
  //     .get('https://your-api-url/api/BlogPosts')
  //     .then((response) => {
  //       setBlogPosts(response.data);
  //     })
  //     .catch((error) => {
  //       console.error('There was an error fetching the blog posts!', error);
  //     });
  // }, []);

  return (
    <div
      className='h-full bg-cover'
      style={{ backgroundImage: `url(${heroPattern.src})` }}
    >
      <div className='flex flex-col justify-center items-center gap-20 text-black'>
        <h1>Blog Articles</h1>
        {blogPosts.map((post: any) => (
          <div key={post.id} className='w-1/2'>
            <div className='relative w-full'>
              <span className='absolute p-1 left-4 -top-7 rounded-t bg-gray-800/50 text-sm text-white'>
                {new Date(post.createdAt).toLocaleDateString('tr-TR', {
                  weekday: 'long',
                  year: 'numeric',
                  month: 'long',
                  day: '2-digit',
                })}
              </span>
            </div>
            <div className='bg-white rounded-xl'>
              <h2>{post.title}</h2>
              <p>{post.content}</p>
              <p>
                <small>
                  Gönderen {post.user.username} zaman:
                  {new Date(post.createdAt).toLocaleTimeString('tr-TR', {
                    hour: '2-digit',
                    minute: '2-digit',
                    second: '2-digit',
                    hour12: false,
                    timeZone: 'Europe/Istanbul',
                  })}
                  yorum: {post.comment.length}
                </small>
              </p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Home;
