<template>
  <div>
    <div>
      <ul class="hover-effect-scale">
        <li v-for="film in films" :key="film.id" class="film">
          <img :src="film.poster" alt="">
          <div>
            <h3>{{ film.title }}</h3>
            <a :href="'/film/'+ film.id">Смотреть</a>
          </div>
        </li>
      </ul>
      <div v-if="showNoFilms">
        <div class="no-films">Фильмы не найдены</div>
      </div>
      <div v-if="showLoader && films.length !== 0" class="loader-container">
        <div class="loader"></div>
      </div>
    </div>
    <div ref="loadMoreTrigger"></div>
  </div>
</template>

<script>
import {ref, computed, onMounted, watch} from 'vue';
import {useStore} from 'vuex';

export default {
  setup() {
    const store = useStore();

    const isLoading = ref(false);
    const isFetching = ref(false);
    const isFilmsLoaded = ref(false); // добавляем новое состояние

    const loadFilms = async (page = 1) => {
      if (isFetching.value) return;
      isFetching.value = true;
      isLoading.value = true;
      const {selectedCountry, selectedGenre, year, title} = store.state.films;
      await store.dispatch("films/getFilmsApi", {page, country: selectedCountry, genre: selectedGenre, year, title});
      isLoading.value = false;
      isFetching.value = false;
      isFilmsLoaded.value = true; // переключаем флаг после загрузки фильмов
      store.commit('films/setPage', page);
    };

    const loadMoreTrigger = ref(null);

    const resetAndLoadFilms = async () => {
      store.commit('films/resetFilms');
      await loadFilms(); // Дождаться окончания загрузки первой страницы
      // create an IntersectionObserver and load more films when element is in view
      const observer = new IntersectionObserver((entries) => {
        const [entry] = entries;
        if (entry.isIntersecting) {
          loadFilms(store.state.films.page + 1);
        }
      });
      observer.observe(loadMoreTrigger.value);
    };

    onMounted(() => {
      // load films from API if there are none in the store
      if (store.state.films.films.length === 0) {
        resetAndLoadFilms();
      }
    });

    watch(() => store.state.films.selectedCountry, resetAndLoadFilms);
    watch(() => store.state.films.selectedGenre, resetAndLoadFilms);
    watch(() => store.state.films.year, resetAndLoadFilms);
    watch(() => store.state.films.title, resetAndLoadFilms);

    const films = computed(() => {
      const filmsSet = new Set();
      const filmsArr = store.state.films.films.filter((film) => {
        if (filmsSet.has(film.id)) {
          return false;
        } else {
          filmsSet.add(film.id);
          return true;
        }
      });
      return filmsArr;
    });

    const showLoader = computed(() => {
      const {currentPage, totalPages} = store.state.films;
      return !isLoading.value && currentPage < totalPages;
    });

    const showNoFilms = computed(() => {
      const {films} = store.state.films;
      return isFilmsLoaded.value && films.length === 0; // показываем сообщение только если фильмы загружены и их нет
    });

    return {
      isLoading,
      films,
      loadMoreTrigger,
      showLoader,
      showNoFilms // добавляем новое вычисляемое свойство
    };
  }


};
</script>


<style scoped>
ul {
  display: flex;
  flex-wrap: wrap;
}

li {
  list-style-type: none;
  margin-right: 20px;
  margin-bottom: 20px;
}

.hover-effect-scale {
  list-style: none;
  margin: 0 auto;
  width: 100%;
  text-align: center;
  padding: 0;
}

.hover-effect-scale li {
  position: relative;
  display: inline-block;
  box-shadow: 1px 3px 1px 0 rgba(0, 0, 0, 0.08);
  overflow: hidden;
}

/* Заголовок, текст и ссылка */
.hover-effect-scale li h3 {
  color: #fff;
  margin: 5px;
}

.hover-effect-scale li a {
  display: block;
  text-decoration: none;
  padding: 15px;
  color: #fff;
  background: #000;
  border-radius: 5px;
  margin: 0 auto;
  transition: all 0.4s ease-in-out;
}

.hover-effect-scale li a:hover {
  background: #454545;
  color: #fff;
}

/* Выезжающий блок с текстом */
.hover-effect-scale li > div {
  width: 100%;
  height: 100%;
  position: absolute;
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.hover-effect-scale li:hover > div {
  position: absolute;
  overflow: hidden;
  top: 0;
  left: 0;
}

.hover-effect-scale li div {
  opacity: 0;
  background-color: rgba(0, 0, 0, 0.35); /* Фон блока при наведении */
  transition: all 0.4s ease-in-out;
  color: #fff;
}

.hover-effect-scale li img {
  width: 210px;
  background-color: #392661;
  height: 319px;
  transition: all 0.2s linear;
}

.hover-effect-scale li:hover img {
  transform: scale(1.3);
}

.hover-effect-scale li:hover div {
  opacity: 1;
}

.loader-container {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 20px;
}

.loader {
  border: 5px solid #ffddcc;
  border-top: 5px solid #4e3883;
  border-radius: 50%;
  width: 30px;
  height: 30px;
  animation: spin 2s linear infinite;
  margin: auto;
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}

.no-films {
  font-size: 30px;
  color: #efefef;
}

@media (max-width: 1000px) {
  .hover-effect-scale {
    justify-content: center;
  }

  .no-films {
    text-align: center;
  }
}

@media (max-width: 752px) {
  .hover-effect-scale li img {
    width: 160px;
    height: 244px;
  }

  li {
    margin: 0 10px 20px;
  }

  .hover-effect-scale li h3 {
    color: #fff;
    margin: 5px;
    font-size: 16px;
  }

  .hover-effect-scale li a {
    font-size: 14px;
  }
}

</style>