<template>
  <div class="season">
    <span class="name-season">{{ season.numberSeason }} сезон </span>
    <div class="episodes">
      <div v-for="(episode) in sortedEpisodes" :key="episode.numberEpisode" class="episode">
        <series-episodes :episode="episode" :seriesId="seriesId" :seasonId="season.numberSeason"
                         :voiceoverId="voiceoverId"/>
      </div>
    </div>
  </div>
</template>

<script>
import SeriesEpisodes
  from "@/components/Pages/SeriesPage/SeriesVideoPlayer/SeriesSeasons/SeriesEpisodes/SeriesEpisodes";

export default {
  name: "SeriesSeasons",
  components: {SeriesEpisodes},
  props: {
    season: {
      type: Object
    },
    seriesId: {
      type: String
    },
    voiceoverId: {
      type: String
    }
  },
  setup(props) {
    function sort_by_key(array, key) {
      return array.sort(function (a, b) {
        var x = a[key];
        var y = b[key];
        return ((x < y) ? -1 : ((x > y) ? 1 : 0));
      });
    }

    const sortedEpisodes = sort_by_key(props.season.episodes, "numberEpisode")

    return {
      sortedEpisodes
    }
  }
}
</script>

<style scoped>
.name-season {
  color: #ffddcc;
  font-size: 30px;
  font-weight: 600;
  line-height: 50px;
  margin-bottom: 20px;
}

.season {
  display: block;
}

.episodes {
  max-width: 100%;
  display: flex;
  flex-wrap: wrap;
}

.episode {
  display: block;
  background-color: #392661;
  width: 300px;
  height: 170px;
  margin: 0 50px 50px 0;
}

@media (max-width: 1340px) {
  .episode {
    max-width: 200px;
    height: 140px;
    margin: 0 30px 30px 0;
  }
}

@media (max-width: 752px){
  .episode {
    max-width: 150px;
    height: 100px;
    margin: 0 20px 20px 0;
  }
}
</style>