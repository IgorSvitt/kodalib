<template>
  <div class="search">
    <input type="text" v-model="state.title" placeholder="Поиск" class="search-input">
  </div>
  <div class="filter-container">

    <div>
      <select v-model="state.selectedCountry">
        <option disabled value="" class="filter-item">Страна</option>
        <option v-for="country in countries" :key="country" class="filter-item">{{ country }}</option>
      </select>
    </div>
    <div>
      <select v-model="state.selectedGenre">
        <option disabled value="" class="filter-item">Жанр</option>
        <option v-for="genre in genres" :key="genre" class="filter-item">{{ genre }}</option>
      </select>
    </div>
    <div>
      <select v-model="state.year">
        <option disabled value="" class="filter-item">Год</option>
        <option v-for="year in state.years" :key="year" class="filter-item">{{ year }}</option>
      </select>
    </div>
    <div>
      <button @click="applyFilters" class="btn-apply">Применить</button>
    </div>
    <div>
      <button @click="resetFilters" class="btn-reset">Сбросить</button>
    </div>
  </div>
</template>

<script>
import {computed, onMounted, reactive} from 'vue';
import {useStore} from "vuex";
import {useRoute} from "vue-router";

export default {
  setup() {
    const store = useStore()
    const route = useRoute();
    const state = reactive({
      selectedCountry: '',
      selectedGenre: '',
      year: '',
      years: [],
      title: ""
    });

    for (let i = 2010; i <= 2023; i++) {
      state.years.push(i.toString());
    }

    const applyFilters = async () => {
      store.commit('series/setSelectedCountry', state.selectedCountry);
      store.commit('series/setSelectedGenre', state.selectedGenre);
      store.commit('series/setSelectedYear', state.year);
      store.commit('series/setSelectedTitle', state.title);
      store.commit('series/setFilms', []); // очищаем список фильмов
      await store.dispatch('series/getSeriesApi', { page: 1, country: state.selectedCountry, genre: state.selectedGenre, year: state.year, title: state.title });
    };

    const resetFilters = async () => {
      state.selectedCountry = '';
      state.selectedGenre = '';
      state.year = '';
      state.title = '';
      await applyFilters();
    };

    const genres = computed(() => store.getters['genres/genreNames']);
    const countries = computed(() => store.getters['country/countryNames']);

    onMounted(async () => {
      const title = route.query.q;
      console.log(title)
      store.commit('series/setSelectedTitle', title);
      await store.dispatch('genres/getGenresApi');
      await store.dispatch('country/getCountriesApi');
    });

    return {
      state,
      applyFilters,
      resetFilters,
      genres,
      countries
    };
  },
};
</script>



<style scoped>

*, *::before, *::after {
  box-sizing: border-box;
}

.filter-container {
  background: rgba(0,0,0,15%);
  padding: 57px;
  border-radius: 20px;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 1rem;
}


input {outline:none;}

.search{
  width: 100%;
  text-align: center;
}
.search-input{
  padding: 10px 10px 10px 20px;
  width: auto;
  margin: 10px;
  width: 90%;
  border: none;
  border-radius: 20px;
  background: rgba(255, 255, 255, 0.16);
  color: #efefef;
}


select,
.btn-apply,
.btn-reset
{
  padding: 0 20px;
  width: 196px;
  height: 40px;
  color: #efefef;
  font-size: 18px;
  background: none;
  border: 3px solid #ffddcc;
  border-radius: 40px;
  transition: all .4s ease;
}

.filter-item {
  background: #392661;
  border: none;
}

select:focus {
  outline: none;
}

select:hover {
  box-shadow: 0 0 20px #;
  cursor: pointer;
  transition: all .4s ease;
}

.btn-apply:hover,
.btn-reset:hover{
  cursor: pointer;
  box-shadow: 0 0 20px #4e3883;
  transition: all .4s ease;
  font-size: 19px;
}

.btn-apply{
  background: #392661;
  border: none;
}

@media (max-width: 752px){
  select,
  .btn-apply,
  .btn-reset{
    font-size: 14px;
    padding: 0 10px;
    width: 160px;
    height: 40px;
  }
  .filter-container{
    padding: 20px;
  }
}
</style>
