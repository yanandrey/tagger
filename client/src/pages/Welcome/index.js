import React from 'react';
import {Link} from 'react-router-dom';
import './styles.css';

export default function Video(){
    return(
        <div className="Video-Container">
            <header>
                <span>You should try tagging some videos or see them.</span>
                <Link className="video-button" to="/video">See them</Link>
                <Link className="tagvideo-button" to="/tagvideo">Try now</Link>
            </header>
        </div>
    )
}