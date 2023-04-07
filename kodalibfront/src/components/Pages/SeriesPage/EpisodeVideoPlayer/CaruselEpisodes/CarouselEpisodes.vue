<template>
  <carousel :settings="settings" :breakpoints="breakpoints">
    <slide v-for="(episode) in sortedEpisodes" :key="episode.id">
      <div class="carousel-img" @click="$router.push('/series/'+route.params.id+'/season/'+route.params.season_id+'/episode/'+episode.numberEpisode+'/voiceover/'+route.params.voiceover_id)">
        <img :src="episode.image" class="img-episode">
        <p>
          <span class="episode-number">{{episode.numberEpisode}} серия</span>
        </p>
      </div>
    </slide>
    <template #addons>
      <navigation />
    </template>
  </carousel>
</template>
<script>

import 'vue3-carousel/dist/carousel.css';
import { Carousel, Slide, Navigation } from 'vue3-carousel';
import {useRoute} from "vue-router";

export default {
  name: 'CarouselEpisodes',
  props:{
    episodes:[],
    currentSlide:{
      type: String
    }
  },
  components: {
    Carousel,
    Slide,
    Navigation,
  },
  setup(props){
    const route = useRoute()

    function sort_by_key(array, key)
    {
      return array.sort(function(a, b)
      {
        var x = a[key]; var y = b[key];
        return ((x < y) ? -1 : ((x > y) ? 1 : 0));
      });
    }

    const sortedEpisodes = sort_by_key(props.episodes.episodes, "numberEpisode")
    return{
      route,
      sortedEpisodes
    }
  },
  data: () => ({
    // carousel settings
    settings: {
      itemsToShow: 1,
      snapAlign: 'center',
      mouseDrag: false,
    },
    // breakpoints are mobile first
    // any settings not specified will fallback to the carousel settings
    breakpoints: {
      // 700px and up
      752: {
        itemsToShow: 2,
        snapAlign: 'center',
      },
      // 1024 and up
      1024: {
        itemsToShow: 4,
        snapAlign: 'center',
      },
    },
  }),
};
</script>

<style scoped>
.img-episode {
  width: 250px;
  height: 170px;
  object-position: center center;
  object-fit: cover;
  transition: all 0.1s ease;
  border-radius: 10px;
}

.img-episode:hover {
  cursor: pointer;
  border: 3px solid #ffddcc;
  transition: all 0.1s ease;
  box-shadow:0 0 30px #ffddcc;
}

.carousel-img{
  margin-top: 20px;
  text-align: left;
}

.episode-number{
  color: #ffddcc;
  font-size: 20px;
}

@media (max-width: 1340px) {
  .img-episode {
    max-width: 200px;
    height: 140px;
  }
}

</style>