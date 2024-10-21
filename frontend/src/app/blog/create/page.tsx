'use client';

import { createBlog } from '@/libs/blog/createBlog';
import { AppDispatch } from '@/store/store';
import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { useDispatch } from 'react-redux';

const CreateBlog = () => {
  const router = useRouter();
  const dispatch = useDispatch<AppDispatch>();
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    dispatch(createBlog({ content, title }));
    router.push('/blog')
  };

  return (
    <div className='max-w-4xl mx-auto mt-8 bg-white p-8 rounded shadow text-gray-700'>
      <div>
        <h1 className='text-2xl font-bold mb-6'>Create New Post</h1>
      </div>
      <form onSubmit={handleSubmit}>
        <div className='mb-4'>
          <label className='block text-sm font-medium mb-2' htmlFor='title'>
            Title
          </label>
          <input
            id='title'
            type='text'
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            className='w-full px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring focus:border-blue-500'
            placeholder='Enter post title'
            required
          />
        </div>

        <div className='mb-4'>
          <label className='block text-sm font-medium mb-2' htmlFor='content'>
            Content
          </label>
          <textarea
            id='content'
            value={content}
            onChange={(e) => setContent(e.target.value)}
            className='w-full px-3 py-2 border border-gray-300 rounded focus:outline-none focus:ring focus:border-blue-500'
            rows={6}
            placeholder='Enter post content'
            required
          />
        </div>

        <button
          type='submit'
          className='px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600'
        >
          Submit
        </button>
      </form>
    </div>
  );
};

export default CreateBlog;
