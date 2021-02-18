import React from 'react';
import './styles.css';

export default function TagVideo(){
    return(
        <div className="tagvideo-container">
            <form>
                <h1>Tag some videos</h1>
                <input placeholder="Title"/>
                <input placeholder="Link"/>
                <input placeholder="Tag"/>
                <button className="button" type="submit">Tag!</button>
            </form>

        </div>
    );
}