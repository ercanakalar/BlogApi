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
    },
    {
      id: 2,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
    },
    {
      id: 3,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
    },
    {
      id: 4,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
    },
    {
      id: 5,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
    },
    {
      id: 6,
      title: 'sen gelmezsen ben gelmem',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur officiis facere rem laudantium sequi iure, repudiandae, est corporis fuga dolorum nobis, pariatur quam nihil incidunt animi. Asperiores totam voluptatem consectetur.',
      createdAt: Date.now(),
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
      className='h-screen bg-cover'
      style={{ backgroundImage: `url(${heroPattern.src})` }}
    >
      <div className='flex flex-col justify-center items-center gap-20 text-black'>
        <h1>Blog Articles</h1>
        {blogPosts.map((post: any) => (
          <div key={post.id} className='w-1/2'>
            <span>{new Date(post.createdAt).toLocaleString()}</span>
            <div className='bg-white rounded-xl'>
              <h2>{post.title}</h2>
              <p>{post.content}</p>
              <p>
                <small>
                  Created at: {new Date(post.createdAt).toLocaleString()}
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
