# ScanBox

## Описание

Мини-сервис, позволяющий выполнять базовые функции по движению товаров.

#### Приход товара на склад

* Создание товара
* Генерация штрих-кода
* Печать штрих-кода
* Приход товара

#### Списание товара

* Создание отгрузки товара
* Сканирование товара
* Проверка на соответствие отсканированных товаров со списком товаров в отгрузке
* Списание товара

#### Отслеживание истории движения товара

* Ведение истории
* Просмотр истории
* Архив

***

## Логика

### Сущности

**1. Товарная единица**

- UID (unique) (pk)
- ID типа товара
- ID поставщика
- Дата производства
- Процент уценки

**2. Тип товара**

- ID (unique) (pk)
- Штрихкод (unique)
- Название продукта
- Категория (fk)
- Производитель (fk)
- Длина
- Высота
- Ширина
- Вес
- Количество 
- Цена товара (fk)

**3. Категория товара**

- ID (unique) (pk)
- Категория (unique)
- Описание (nullable)

**4. Поставщики**

- ID (unique) (pk)
- ID контрагента (fk)

**5. Покупатели**

- ID (unique) (pk)
- ID контрагента (fk)

**6. Производители**

- ID (unique) (pk)
- ID контрагента (fk)

**7. Правовые формы**

- ID (unique) (pk)
- Правовая форма
- Описание (nullable)

**8. Документ (приход, уход)**

- ID (unique) (pk)
- Сотрудник склада (fk)
- Дата создания накладной
- ID типа накладной

**9. Тип документа (накладной)**

- ID (unique) (pk)
- Название типа документа
- Описание состояния товара

**10. Накладные поступления**

- ID (unique) (pk)
- ID накладной (fk)
- ID Поставщика (fk)

**11. Накладные реализации**

- ID (unique) (pk)
- ID накладной (fk)
- ID Покупателя (fk)

**12. История движения**

- ID (unique) (pk)
- ID накладной (fk)
- UID товара (fk)

**13. Работники склада**  

- ID (unique) (pk)
- ID должности (fk)
- Фамилия
- Имя
- Отчество (nullable)
- Дата рождения
- Дата найма
- Адрес
- Телефон

**14. Должности**  

- ID (unique) (pk)
- Название должности (unique)
- Описание обязанностей (nullable)
- Оклад

**15. Цены**

- ID товара (unique) (pk) (fk)
- Цена по себестоимости
- Цена розничная
- Цена оптовая

**16. Тип контрагента**

- ID (unique) (pk)
- Тип (юрлицо / физлицо)

**17. Контрагент**

- ID (unique) (pk)
- ID Типа контрагента
- Почтовый адрес
- Телефон
- E-mail (nullable)

**18. Физическое лицо**

- ID (unique) (pk)
- ID контрагента (fk)
- Фамилия
- Имя
- Отчество

**19. Юридическое лицо**

- ID (unique) (pk)
- ID контрагента (fk)
- Правовая форма (fk)
- Название юридического лица
- Фамилия руководителя
- Имя руководителя
- Отчество руководителя (nullable)
- ИНН
- КПП
- ОГРН
- Юридический адрес
- Контактное лицо (nullable)

***

### Инструменты

- Генератор штрихкода
- Вывод штрихкода
- Сканер
- Валидатор отгрузки

***  

(далее - ДЕМО)

### Разработка

**Контроллеры по сущностям, краткий список:**

1. Товар
2. Категория товара
3. Поставщики
4. Правовые формы
5. Накладные прихода
6. Накладные реализации
7. Список товара на приход
8. Список товара на реализацию
9. Работники склада
10. Должности
11. Цены
12. Покупатель
13. Юридическое лицо
14. Уценка

**Контроллеры по сущностям, развернутый список:**

**1. Товар** (содержит fk)  


**2. Категория товара**  

**3. Поставщики** (содержит fk)   

**4. Правовые формы**  
Добавление правовой формы  
Удаление правовой формы  
Обновление правовой формы

**5. Накладные прихода** (содержит fk)  

**6. Накладные реализации** (содержит fk)  

**7. Список товара на приход** (содержит fk)  

**8. Список товара на реализацию** (содержит fk)  

**9. Работники склада** (содержит fk)  

**10. Должности**  
Добавление должности  
Удаление должности
Изменение должности

**11. Цены** (содержит fk)  

**12. Покупатель** (содержит fk)  

**13. Юридическое лицо** (содержит fk)  

**14. Уценка** (содержит fk)  
